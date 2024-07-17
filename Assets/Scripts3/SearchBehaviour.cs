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
    public float areaSize = 4f;

    Transform player;
    float chaseRange = 10.0f;

    public void Start()
    {
        agent = animator.GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("isSearching", true);
        agent.speed = 3f;
        agent.SetDestination(rigidbody.transform.position);
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(agent.transform.position, rigidbody.transform.position) < areaSize){
            animator.SetBool("isSearching", false);
            agent.speed = 0.5f;
        }

        float distance = Vector3.Distance(animator.transform.position, player.transform.position);

        if (distance < chaseRange){
            animator.SetBool("isChasing", true);
        }
    }
}