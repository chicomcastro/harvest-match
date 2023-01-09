using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
        if (flowerBehaviour == null)
        {
            return;
        }
        flowerBehaviour.HighlightFlower();
    }

    private void OnTriggerExit(Collider other)
    {
        FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
        if (flowerBehaviour == null)
        {
            return;
        }
        flowerBehaviour.UnhighlightFlower();
    }
}
