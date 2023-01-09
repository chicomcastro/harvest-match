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

    private Vector3 target;

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
            desiredFlowers.Add(desiredFlower);
        }

        target = LevelManager.instance.tends[0].transform.position;
        target = target - new Vector3(0, target.y - transform.position.y, 0);
        GetComponent<NavMeshAgent>().destination = target;
    }

    private void Update()
    {
        transform.LookAt(target);

        float distance = (target - transform.position).magnitude;
        print(distance);
        if (distance < 1.75f)
        {
            customerCanvasPanel.SetActive(true);
        }
    }
}
