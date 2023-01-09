using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(flowerPrefab, transform.position + new Vector3(0,0.3f,0), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
