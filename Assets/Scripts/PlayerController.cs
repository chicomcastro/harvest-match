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
        StartCoroutine(DeliveryFlower());
    }

    private IEnumerator DeliveryFlower()
    {
        GameObject currentTend = LevelManager.instance.tends[0];
        yield return new WaitUntil(() =>
        {
            float distance = (transform.position - currentTend.transform.position).magnitude;
            return distance < 1.2f;
        });
        currentTend.GetComponent<CustomerService>().DeliveryCustomerOrder(harvestedFlowerColor);
        holdingFlower.SetActive(false);
    }
}
