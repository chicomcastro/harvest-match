using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public Transform spawn;
    public GameObject customerPrefab;

    public static CustomerSpawner instance;

    private GameObject currentCustomer;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnNewCustomer()
    {
        if (!FlowerDiversityController.instance.HasAvailableFlowers())
        {
            GameManager.instance.GameOver();
        }
        currentCustomer = Instantiate(customerPrefab, spawn.position, Quaternion.identity);
        StartCoroutine(WaitCustomerToLeave());
    }

    private IEnumerator WaitCustomerToLeave()
    {
        yield return new WaitUntil(() => currentCustomer == null);
        SpawnNewCustomer();
    }
}
