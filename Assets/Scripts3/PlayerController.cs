using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Quaternion yForward = Quaternion.Euler(0, -90, 0);
    Quaternion yRight = Quaternion.Euler(0, 90, 0);
    // Ссылка на компонент StaminaController
    public StaminaController staminaController;

    // Скорость движения
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Вычисление направления движения
        Vector3 forwardDirection = yRight * rb.transform.forward * Input.GetAxis("Horizontal");
        Vector3 rightDirection = yForward * rb.transform.right * Input.GetAxis("Vertical");
        // Проверка, нажата ли клавиша бега
        if (Input.GetKey(KeyCode.LeftShift) && !staminaController.IsStaminaDepleted())
        {
            // Бег, если есть выносливость
            rb.velocity = (forwardDirection + rightDirection) * runSpeed;

            // Расход выносливости
            staminaController.ConsumeStamina(Time.deltaTime * 30f);
        }
        else
        {
            // Ходьба
            rb.velocity = (forwardDirection + rightDirection) * walkSpeed;

            // Восстановление выносливости, если она была истощена
            staminaController.ResetStaminaDepletion();
        }
    }
}