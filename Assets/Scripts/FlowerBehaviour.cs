using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public GameObject petalsObj;

    private GameObject playerObj;
    private readonly float harvestingDistance = 1.5f;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        Material[] flowerKinds = FlowerDiversityController.instance.flowerKinds;
        petalsObj.GetComponent<MeshRenderer>().material = flowerKinds[Random.Range(0, flowerKinds.Length)];
        originalColor = petalsObj.GetComponent<MeshRenderer>().material.color;

        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseDown()
    {
        Vector3 posDiff = playerObj.transform.position - transform.position;
        if (posDiff.magnitude > harvestingDistance)
        {
            return;
        }
        HarvestFlower();
    }

    public void HarvestFlower()
    {
        Destroy(this.gameObject);
        UnhighlightFlower();
        playerObj.GetComponent<PlayerController>().HarvestFlower(petalsObj.GetComponent<MeshRenderer>().material);
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
