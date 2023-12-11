using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationType : StateMachineBehaviour
{
    [SerializeField]    public AbilityType abilityType;
    public AnimationClip clip { get; private set; }

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateIK(animator, stateInfo, layerIndex);
        stateInfo.
    }
    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        base.OnStateIK(animator, stateInfo, layerIndex, controller);
        stateInfo.
    }
    public void ov
        ()
    {
        
    }



}
