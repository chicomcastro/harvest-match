using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerStay(Collider other)
    {
        print("can harvest");
        if (Input.GetButtonDown("Fire1"))
        {
            FlowerBehaviour flowerBehaviour = other.gameObject.GetComponent<FlowerBehaviour>();
            if (flowerBehaviour != null)
            {
                print("have harvest");
                flowerBehaviour.HarvestFlower();
            }
        }
    }
}
