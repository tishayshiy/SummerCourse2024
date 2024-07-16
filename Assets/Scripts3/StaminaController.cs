using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    // Максимальная выносливость
    public float maxStamina = 100f;

    // Текущая выносливость
    public float currentStamina;

    // Скорость восстановления выносливости
    public float staminaRegenRate = 10f;

    // Флаг, указывающий, что выносливость истощена
    private bool isStaminaDepleted = false;

    void Start()
    {
        // Инициализация текущей выносливости
        currentStamina = maxStamina;
    }

    void FixedUpdate()
    {
        // Восстановление выносливости, если она не полностью истощена
        if (currentStamina < maxStamina && !isStaminaDepleted)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        // Предотвращение превышения максимального уровня выносливости
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    // Метод для расхода выносливости
    public void ConsumeStamina(float amount)
    {
        // Проверка, достаточно ли выносливости
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
        }
        else
        {
            // Выносливость истощена, флаг устанавливается
            isStaminaDepleted = true;
        }
    }

    // Метод для проверки, истощена ли выносливость
    public bool IsStaminaDepleted()
    {
        return isStaminaDepleted;
    }

    // Метод для сброса флага истощения выносливости
    public void ResetStaminaDepletion()
    {
        isStaminaDepleted = false;
    }
}
