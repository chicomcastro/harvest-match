using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private string pickupButton;

    private List<FlowerBehaviour> pickupableFlowers = new List<FlowerBehaviour>();

    private void OnTriggerEnter(Collider other)
    {
        FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
        if (flowerBehaviour == null)
        {
            return;
        }
        flowerBehaviour.HighlightFlower();
        pickupableFlowers.Add(flowerBehaviour);
    }

    private void OnTriggerExit(Collider other)
    {
        FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
        if (flowerBehaviour == null)
        {
            return;
        }
        flowerBehaviour.UnhighlightFlower();
        pickupableFlowers.Remove(flowerBehaviour);
    }

    private void Update()
    {
        if (Input.GetButtonDown(pickupButton) && pickupableFlowers.Count > 0)
        {
            FlowerBehaviour pickupableFlower = pickupableFlowers[pickupableFlowers.Count - 1];
            pickupableFlower.HarvestFlower(playerController);
            pickupableFlowers.Remove(pickupableFlower);
        }
    }
}
