using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerService : MonoBehaviour
{
    private GameObject currentCustomer;

    public void RegisterCustomer(GameObject customer)
    {
        currentCustomer = customer;
    }

    public void DeliveryCustomerOrder(Color deliveredFlower)
    {
        currentCustomer.GetComponent<CustomerBehaviour>().ReceiveOrder(deliveredFlower);
    }
}
