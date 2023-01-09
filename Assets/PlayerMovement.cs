using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private readonly float horizontalSpeed = 1f;
    private readonly float verticalSpeed = 1f;

    private NavMeshAgent agent;

    public float displacementOffset = 1f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * horizontalSpeed;
        float rotation = Input.GetAxis("Horizontal") * verticalSpeed;

        Vector3 movingDir = (Vector3.forward * translation + Vector3.right * rotation).normalized;
        Vector3 targetPos = transform.position + movingDir * displacementOffset;
        agent.destination = targetPos;
    }
}
