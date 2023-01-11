using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCanvasToCamera : MonoBehaviour
{
    private GameObject camObj;

    // Start is called before the first frame update
    void Start()
    {
        camObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = camObj.transform.position;
        Vector3 diffPos = camPos - transform.position;
        Vector3 zyProjection = new Vector3(0, diffPos.y, diffPos.z);
        transform.LookAt(transform.position - zyProjection, new Vector3(0, diffPos.y, 0));
    }
}
