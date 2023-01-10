using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public GameObject petalsObj;

    private readonly float harvestingDistance = 1.5f;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerController = transform.GetComponentInParent<PlayerController>();
        if (playerController != null)
        {
            return;
        }
        Material newFlower = FlowerDiversityController.instance.GenerateNewFlower(this.gameObject);
        petalsObj.GetComponent<MeshRenderer>().material = newFlower;
        originalColor = petalsObj.GetComponent<MeshRenderer>().material.color;
    }

    public void HarvestFlower(PlayerController playerController)
    {
        UnhighlightFlower();
        playerController.HarvestFlower(petalsObj.GetComponent<MeshRenderer>().material);
        FlowerDiversityController.instance.FlowerWasHarvested(this.gameObject);
        TimeManager.instance.StartDeliveryTimer();
        Destroy(this.gameObject);
    }

    public void HighlightFlower()
    {
        petalsObj.GetComponent<MeshRenderer>().material.color = originalColor * 1.5f;
    }

    public void UnhighlightFlower()
    {
        petalsObj.GetComponent<MeshRenderer>().material.color = originalColor;
    }
}
