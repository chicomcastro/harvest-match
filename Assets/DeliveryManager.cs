using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private string deliveryButton;

    private CustomerService currentCustomerService;

    private void OnTriggerEnter(Collider other)
    {
        CustomerService customerService = other.gameObject.GetComponent<CustomerService>();
        if (customerService == null)
        {
            return;
        }
        currentCustomerService = customerService;
    }

    private void OnTriggerExit(Collider other)
    {
        CustomerService customerService = other.gameObject.GetComponent<CustomerService>();
        if (customerService == null)
        {
            return;
        }
        currentCustomerService = null;
    }

    private void Update()
    {
        if (Input.GetButtonDown(deliveryButton) && currentCustomerService != null)
        {
            playerController.DeliveryFlowerOn(currentCustomerService);
        }
    }
}
