using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flowerPrefab;

    void Start()
    {
        Instantiate(flowerPrefab, transform.position + new Vector3(0,0.3f,0), Quaternion.identity, transform);
    }
}
