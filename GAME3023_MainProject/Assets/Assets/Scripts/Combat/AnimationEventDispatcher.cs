using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AnimationEventDispatcher : MonoBehaviour
{
    public Ability IdleAnimation;
    public AnimationEventDispatcher(Animator animator, List<Ability> abilities)
    {

        AnimatorController AnimatorController = animator.runtimeAnimatorController as AnimatorController;
        AnimationType[] StateTypes = AnimatorController.GetBehaviours<AnimationType>();
        AnimationClip[] AnimationClips = AnimatorController.animationClips;

        StoreStateNames(StateTypes, AnimationClips);

        foreach (var Ability in abilities)
        {
            BindAnimationAbilities(StateTypes, Ability);
            BindAnimationEvents(AnimationClips, Ability);
        }

        IdleAnimation = new Ability(new AbilityBase());
        IdleAnimation.Base.Type = AbilityType.Idle;
        BindAnimationAbilities(StateTypes, IdleAnimation);

    }

    public void StoreStateNames(AnimationType[] AnimatorStateTypes, AnimationClip[] animations)
    {
        for (int j = 0; j < AnimatorStateTypes.Length; j++)
        {
            AnimatorStateTypes[j].StateName = animations[j].name;
        }
    }

    public void BindAnimationAbilities(AnimationType[] AnimatorStateTypes, Ability ability)
    {
        foreach (var Behaviour in AnimatorStateTypes)
        {
            if (Behaviour.Type == ability.Base.Type)
            {
                ability.StateName = Behaviour.StateName;
                break;
            }
        }
    }

    public void BindAnimationEvents(AnimationClip[] animations, Ability ability)
    {
        foreach(var Clip in animations)
        {
            if (ability.StateName == Clip.name && Clip.events.Length==0)
            {               
                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = Clip.length;
                animationEndEvent.functionName = "AnimationCompleteHandler";
                animationEndEvent.stringParameter = Clip.name;
                Clip.AddEvent(animationEndEvent);
                break;
            }

        }
    }

    

}
