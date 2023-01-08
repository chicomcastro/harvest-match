using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public GameObject petalsObj;

    // Start is called before the first frame update
    void Start()
    {
        Material[] flowerKinds = FlowerDiversityController.instance.flowerKinds;
        petalsObj.GetComponent<MeshRenderer>().material = flowerKinds[Random.Range(0, flowerKinds.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
