using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private bool rotateTowardMouse;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Camera Camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector.normalized);

        if (!rotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (rotateTowardMouse)
        {
            RotateFromMouseVector();
        }

    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            //var target = hitInfo.point;
            //target.y = transform.position.y;
            //transform.LookAt(target);
            Vector3 targetVector = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
            Quaternion targetRotation = Quaternion.LookRotation(targetVector - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = movementSpeed * Time.deltaTime;
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        //Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}