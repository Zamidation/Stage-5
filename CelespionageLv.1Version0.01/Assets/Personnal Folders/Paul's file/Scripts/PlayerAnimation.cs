using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private AnimationState animationState = AnimationState.NONE;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        switch (animationState)
        {
            case AnimationState.NONE:
                animator.SetBool("isIdling", false);
                animator.SetBool("isSprinting", false);
                break;
            case AnimationState.IDLE:
                animator.SetBool("isIdling", true);
                animator.SetBool("isSprinting", false);
                break;
            case AnimationState.SPRINT:
                animator.SetBool("isIdling", false);
                animator.SetBool("isSprinting", true);
                break;
            default:
                break;
        }
    }
}

public enum AnimationState
{
    NONE = 0,
    IDLE = 1,
    SPRINT = 2
};
