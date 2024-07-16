using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            animator.SetBool("isRunning", true);
        }
        if(Input.GetKeyUp(KeyCode.W)){
            animator.SetBool("isRunning", false);
        }
    }
}
