using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public GameObject camera;
    public int maxSpeed = 5;
    public float acceleretion = 3.0f;

    void Accelerate(Vector3 direction)
    {
        float currentSpeed = rigidbody.velocity.magnitude;
        if (currentSpeed < maxSpeed){
            rigidbody.AddForce(direction * acceleretion, ForceMode.Acceleration);
        }

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            Accelerate(Vector3.left);
        }
         if (Input.GetKey(KeyCode.D)){
            Accelerate(Vector3.right);
        }
    }
}
