using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public GameObject petalsObj;

    private GameObject playerObj;
    private readonly float harvestingDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Material[] flowerKinds = FlowerDiversityController.instance.flowerKinds;
        petalsObj.GetComponent<MeshRenderer>().material = flowerKinds[Random.Range(0, flowerKinds.Length)];

        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseDown()
    {
        Vector3 posDiff = playerObj.transform.position - transform.position;
        if (posDiff.magnitude > harvestingDistance)
        {
            return;
        }
        Destroy(this.gameObject);
        playerObj.GetComponent<PlayerController>().HarvestFlower(petalsObj.GetComponent<MeshRenderer>().material);
    }
}
