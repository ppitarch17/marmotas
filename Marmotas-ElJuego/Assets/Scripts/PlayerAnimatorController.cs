using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public enum AnimationName{
        Walk,
        Run,
        Jump,
        Idle,
    }
    private static Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static void ChangeAnimation(AnimationName name, float transitionTime){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName(name.ToString())){ //If its already playing you dont need to :)
            return;
        }
        animator.Play(name.ToString(), 0, transitionTime);
    }
}
