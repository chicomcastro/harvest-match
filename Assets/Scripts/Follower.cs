using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        transform.position = target.transform.position;
    }
}
