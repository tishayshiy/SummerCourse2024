using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public float attackRange = 2.0f;
    public float chaseRange = 10.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 3.5f;

        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.transform.position);
        float distance = Vector3.Distance(animator.transform.position, player.transform.position);

        if (distance < attackRange){
            animator.SetBool("isAttacking", true);
        }

        if (distance > chaseRange){
            animator.SetBool("isChasing", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 0.5f;
    }
}
