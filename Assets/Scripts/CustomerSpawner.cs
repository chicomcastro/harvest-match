using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Transform spawn;
    public GameObject customerPrefab;

    public static CustomerSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnNewCustomer()
    {
        Instantiate(customerPrefab, spawn.position, Quaternion.identity);
    }
}
