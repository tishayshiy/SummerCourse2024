using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SearchBehaviour : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public Rigidbody rigidbody;
    public float areaSize = 3f;

    public void Start()
    {
        agent = animator.GetComponent<NavMeshAgent>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("isSearching", true);
        agent.speed = 4f;
        agent.SetDestination(rigidbody.transform.position);
    }

    public void FixedUpdate()
    {
        if(Vector3.Distance(agent.transform.position, rigidbody.transform.position) < areaSize){
            animator.SetBool("isSearching", false);
            animator.SetBool("isPatrolling", true);
            agent.speed = 1.5f;
        }
    }
}