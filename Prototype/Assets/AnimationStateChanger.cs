using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    
    [SerializeField] Animator animator;
    [SerializeField] string currentState = "IdleMeepis";

    void Start(){
        ChangeAnimationState(currentState);
    }

    void Update(){

    }

    public void ChangeAnimationState(string newAnimationState){

        if(newAnimationState == currentState){
            return; //skip the change
        }

        currentState = newAnimationState;
        animator.Play(newAnimationState);
    }


}
