using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToContactPoint : MonoBehaviour
{
    public NavMeshAgent agent;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 targetPosition = collision.contacts[0].point;

        agent.SetDestination(targetPosition);
    }
}
