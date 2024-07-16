using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrigger : MonoBehaviour
{
    // Префаб, который будет спавниться
    public GameObject prefabToSpawn;

    // Время, через которое объект будет удален
    public float deleteDelay = 2f;

    // Вызывается при столкновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Создаем новый объект в точке столкновения
        GameObject spawnedObject = Instantiate(prefabToSpawn, collision.contacts[0].point, Quaternion.identity);

        // Удаляем объект через определенное время
        Destroy(spawnedObject, deleteDelay);
    }
}