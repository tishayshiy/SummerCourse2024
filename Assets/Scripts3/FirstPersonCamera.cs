using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float sensetivity = 2.0f;
    float verticalRotation = 0f;

    bool lockedCursor = true;

    void Start()
    {
        Cursor.visible = false;

    }

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * sensetivity;
        float inputY = Input.GetAxis("Mouse Y") * sensetivity;

        verticalRotation -= inputY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * verticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
