using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour
{
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = originalRotation;
    }
}
