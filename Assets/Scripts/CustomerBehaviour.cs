using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CustomerBehaviour : MonoBehaviour
{
    private List<Color> desiredFlowers = new List<Color>();

    public GameObject customerCanvasPanel;
    public GameObject desiringFlowerImagePrefab;
    public List<GameObject> desiringFlowerImageList = new List<GameObject>();

    private Vector3 target;
    private bool hasFinishService = false;

    // Start is called before the first frame update
    void Start()
    {
        print("NEW CUSTOMER --------");
        customerCanvasPanel.SetActive(false);

        int maxDesiredFlowersCount = LevelManager.instance.GetMaxItemLevelMap();
        int desiredFlowersQuant = Random.Range(1, maxDesiredFlowersCount + 1);

        Color[] flowersToRequest = FlowerDiversityController.instance.RequestSomeAvailableFlowerKinds(desiredFlowersQuant);

        for(int i = 0; i < flowersToRequest.Length; i++)
        {
            Color desiredFlower = flowersToRequest[i];
            GameObject gamo = Instantiate(desiringFlowerImagePrefab, customerCanvasPanel.transform);
            gamo.GetComponent<Image>().color = desiredFlower;
            desiringFlowerImageList.Add(gamo);
            desiredFlowers.Add(desiredFlower);
        }

        GameObject targetTend = LevelManager.instance.tends[0];
        targetTend.GetComponent<CustomerService>().RegisterCustomer(this.gameObject);
        target = targetTend.transform.position;
        target = target - new Vector3(0, target.y - transform.position.y, 0);
        GetComponent<NavMeshAgent>().destination = target;
    }

    private void Update()
    {
        transform.LookAt(target);

        float distance = (target - transform.position).magnitude;
        if (distance < 1.75f && !hasFinishService)
        {
            customerCanvasPanel.SetActive(true);
        }
    }

    public void ReceiveOrder(Color order)
    {
        FlowerDiversityController.instance.MarkFlowerAsDelivered(order);
        if (desiredFlowers.Contains(order))
        {
            print("Flower was delivered successfully");
            GameObject gamo = desiringFlowerImageList.Find((flower) => flower.GetComponent<Image>().color == order);
            if (gamo != null)
            {
                desiringFlowerImageList.Remove(gamo);
                Destroy(gamo);
            }
            if (desiringFlowerImageList.Count == 0)
            {
                hasFinishService = true;
                customerCanvasPanel.SetActive(false);
                StartCoroutine(GoAway());
            }
            ScoreManager.instance.CountScore(true);
        }
        else
        {
            // TODO animate angry
            print("This flower was not requested");
            ScoreManager.instance.CountScore(false);
        }
    }

    private IEnumerator GoAway()
    {
        target = transform.position - transform.right * 5f;
        GetComponent<NavMeshAgent>().destination = target;
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        Destroy(this.gameObject);
    }
}
