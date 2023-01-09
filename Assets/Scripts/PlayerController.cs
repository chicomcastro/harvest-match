using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject holdingFlower;

    private void Start()
    {
        holdingFlower.SetActive(false);
    }

    public void HarvestFlower(Material flowerKind)
    {
        holdingFlower.GetComponent<FlowerBehaviour>().petalsObj.GetComponent<MeshRenderer>().material = flowerKind;
        holdingFlower.SetActive(true);
    }

    public void DeliveryFlower()
    {
        holdingFlower.SetActive(false);
    }
}
