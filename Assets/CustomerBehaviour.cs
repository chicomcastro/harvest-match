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
        customerCanvasPanel.SetActive(false);

        int maxDesiredFlowersCount = LevelManager.instance.GetMaxItemLevelMap();
        int desiredFlowersCount = Random.Range(1, maxDesiredFlowersCount + 1);
        Material[] flowerKinds = FlowerDiversityController.instance.flowerKinds;
        for(int i = 0; i < desiredFlowersCount; i++)
        {
            Color desiredFlower = flowerKinds[Random.Range(0, flowerKinds.Length)].color;
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
        if (desiredFlowers.Contains(order))
        {
            print("contem");
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
            ScoreManager.instance.CountScore();
        }
        else
        {
            // TODO animate angry
            print("n�o contem");
        }
    }

    private IEnumerator GoAway()
    {
        target = transform.position - transform.right * 5f;
        GetComponent<NavMeshAgent>().destination = target;
        yield return new WaitForSeconds(0.5f + Random.Range(0.5f, 1f));
        CustomerSpawner.instance.SpawnNewCustomer();
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        this.gameObject.SetActive(false);
    }
}