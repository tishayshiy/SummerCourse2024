using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    Quaternion y = Quaternion.Euler(0, -180, 0);
    public Rigidbody rigidbody;
    public int maxSpeed = 5;
    public float acceleretion = 3.0f;

    void Accelerate(Vector3 direction)
    {
        float currentSpeed = rigidbody.velocity.magnitude;
        if (currentSpeed < maxSpeed){
            rigidbody.AddForce(direction * acceleretion, ForceMode.Acceleration);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)){
            Accelerate(gameObject.transform.forward);
        }
         if (Input.GetKey(KeyCode.S)){
            Accelerate(y * gameObject.transform.forward);
        }
         if (Input.GetKey(KeyCode.D)){
            Accelerate(gameObject.transform.right);
        }
        if (Input.GetKey(KeyCode.A)){
            Accelerate(y * gameObject.transform.right);
        }
    }
}