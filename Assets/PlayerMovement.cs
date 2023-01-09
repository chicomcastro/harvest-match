using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private readonly float verticalSpeed = 1f;
    private readonly float horizontalSpeed = 1f;

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
        float verticalDisplacement = Input.GetAxis("Vertical") * verticalSpeed;
        float horizontalDisplacement = Input.GetAxis("Horizontal") * horizontalSpeed;

        Vector3 movingDir = (Vector3.forward * verticalDisplacement + Vector3.right * horizontalDisplacement).normalized;
        Vector3 targetDisplacement = movingDir.magnitude > 0.1f ? movingDir * displacementOffset * Time.deltaTime : Vector3.zero;
        transform.Translate(targetDisplacement, Space.World);
        if (targetDisplacement.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(targetDisplacement, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
