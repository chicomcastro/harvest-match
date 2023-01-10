using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private string pickupButton;

    private FlowerBehaviour pickupableFlower;

    private void OnTriggerEnter(Collider other)
    {
        FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
        if (flowerBehaviour == null)
        {
            return;
        }
        flowerBehaviour.HighlightFlower();
        pickupableFlower = flowerBehaviour;
        StartCoroutine(HandlePickupFlower());
    }

    private void OnTriggerExit(Collider other)
    {
        FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
        if (flowerBehaviour == null)
        {
            return;
        }
        flowerBehaviour.UnhighlightFlower();
        pickupableFlower = null;
    }

    private IEnumerator HandlePickupFlower()
    {
        yield return new WaitUntil(() => Input.GetButtonDown(pickupButton) || pickupableFlower == null);
        if (pickupableFlower != null)
        {
            pickupableFlower.HarvestFlower(playerController);
        }
    }
}
