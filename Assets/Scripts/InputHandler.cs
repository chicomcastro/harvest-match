using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private string horizontalAxisName = "Horizontal";

    [SerializeField]
    private string verticalAxisName = "Vertical";

    public Vector2 InputVector { get; private set; }
    public Vector3 MousePosition { get; private set; }

    void Update()
    {
        var h = Input.GetAxis(horizontalAxisName);
        var v = Input.GetAxis(verticalAxisName);
        InputVector = new Vector2(h, v);

        MousePosition = Input.mousePosition;
    }
}