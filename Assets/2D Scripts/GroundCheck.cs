using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int maxJumpCount = 2;
    public int jumpCount = 2;
    public float jumpForce = 10.0f;

    public Collider legs;
    public Rigidbody rigidbody;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (jumpCount <= 0){
                return;
            }
            jumpCount -= 1;
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            Debug.Log("Jumped");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Grounded");
        jumpCount = maxJumpCount;
    }
}
