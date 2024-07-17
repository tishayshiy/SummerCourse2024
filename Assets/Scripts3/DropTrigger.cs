using UnityEngine;
using UnityEngine.AI;

public class MoveToCollisionPoint : MonoBehaviour
{
    // Ссылка на Nav Mesh Agent
    public NavMeshAgent agent;

    // Список объектов с Rigidbody
    public GameObject[] rigidbodyObjects;

    // Точка, куда должен двигаться агент
    public static Vector3 targetPosition;

    // Метод, вызываемый при входе коллайдера в триггер
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли коллайдер частью объекта с Rigidbody
        foreach (GameObject obj in rigidbodyObjects)
        {
            if (other.gameObject == obj)
            {
                // Задаем новую точку назначения для агента
                targetPosition = other.ClosestPointOnBounds(transform.position);
                agent.SetDestination(targetPosition);
                break;
            }
        }
    }
}
