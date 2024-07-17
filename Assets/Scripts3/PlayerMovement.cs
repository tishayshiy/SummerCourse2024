using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Quaternion yForward = Quaternion.Euler(0, -90, 0);
    Quaternion yRight = Quaternion.Euler(0, 90, 0);

    public float speed = 5f;
    public float runSpeed = 10f;
    public float stamina = 100f;
    public float staminaRegenRate = 10f;
    private float lastStaminaZeroTime = 0f;

    private Rigidbody rigidbody;

    private bool isRunning = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (stamina < 100 && stamina > 0 && isRunning == false){ 
            stamina += staminaRegenRate * Time.deltaTime;
        }

        else if (stamina < 0 && Time.time - lastStaminaZeroTime > 5f){
            isRunning = false;
            lastStaminaZeroTime = Time.time;
            stamina = 0.1f;
        }

        Vector3 forwardDirection = yRight * rigidbody.transform.forward * Input.GetAxis("Horizontal");
        Vector3 rightDirection = yForward * rigidbody.transform.right * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0){
            rigidbody.AddForce((forwardDirection + rightDirection) * runSpeed, ForceMode.VelocityChange);
            isRunning = true;
            stamina -= 20 * Time.deltaTime;
        }
        else{
            rigidbody.AddForce((forwardDirection + rightDirection) * speed, ForceMode.VelocityChange);
            isRunning = false;
        }
    }
}