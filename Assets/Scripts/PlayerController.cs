using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public GameObject holdingFlower;
    private Color harvestedFlowerColor;

    private void Start()
    {
        holdingFlower.SetActive(false);
    }

    public void HarvestFlower(Material flowerKind)
    {
        harvestedFlowerColor = flowerKind.color;
        holdingFlower.GetComponent<FlowerBehaviour>().petalsObj.GetComponent<MeshRenderer>().material = flowerKind;
        holdingFlower.SetActive(true);
    }

    public void DeliveryFlowerOn(CustomerService customerService)
    {
        customerService.DeliveryCustomerOrder(harvestedFlowerColor);
        holdingFlower.SetActive(false);
    }
}
