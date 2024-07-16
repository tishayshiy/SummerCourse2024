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
        if (stamina < 100 && !isRunning && Time.time - lastStaminaZeroTime > 5f)
        {
            stamina += staminaRegenRate * Time.deltaTime;
        }

        if (stamina < 0)
        {
            isRunning = false;
            lastStaminaZeroTime = Time.time;
            stamina = 0;
        }

        Vector3 forwardDirection = yRight * rigidbody.transform.forward * Input.GetAxis("Horizontal");
        Vector3 rightDirection = yForward * rigidbody.transform.right * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            rigidbody.velocity = (forwardDirection + rightDirection) * runSpeed;
            isRunning = true;
            stamina -= 20 * Time.deltaTime;
        }
        else
        {
            rigidbody.velocity = (forwardDirection + rightDirection) * speed;
        }
    }
}