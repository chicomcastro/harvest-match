using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerBehaviour : MonoBehaviour
{
    private List<Material> desiredFlowers = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        int maxDesiredFlowersCount = LevelManager.instance.GetMaxItemLevelMap();
        int desiredFlowersCount = Random.Range(1, maxDesiredFlowersCount + 1);
        Material[] flowerKinds = FlowerDiversityController.instance.flowerKinds;
        for(int i = 0; i < desiredFlowersCount; i++)
        {
            desiredFlowers.Add(flowerKinds[Random.Range(0, flowerKinds.Length)]);
        }

        GetComponent<NavMeshAgent>().destination = LevelManager.instance.tends[0].transform.position;
    }
}
