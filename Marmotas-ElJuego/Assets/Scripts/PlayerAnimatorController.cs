using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private static Animator _animator;
    public bool canBeInterrupted = true;
    
    public enum AnimationName{
        Walk,
        Run,
        Jump,
        Idle,
        Jump0Preparation,
        Jump1Normal,
        Jump2Landing,
    }
    
    void Start() {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeAnimation(AnimationName name, float transitionTime, bool canBeInterrupted){

        if (!this.canBeInterrupted) {
            Debug.Log("Could not play animation one that cant be interrupted is playing");
            return;
        }
            

        if (!_animator.IsInTransition(0)) {
            
            _animator.CrossFade(name.ToString(), transitionTime);

            if (!canBeInterrupted) {
                this.canBeInterrupted = false;
                Invoke(nameof(CanBeInterruptedAfterFinish), _animator.GetCurrentAnimatorStateInfo(0).length);
            }
                
        }
            
    }

    private void CanBeInterruptedAfterFinish() { //Set to true after the animation that cant be interrupted is finished
        canBeInterrupted = true;
    }
}
