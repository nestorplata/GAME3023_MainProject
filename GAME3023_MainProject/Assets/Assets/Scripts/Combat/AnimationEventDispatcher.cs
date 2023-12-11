using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityAnimationEvent : UnityEvent<int> { };
public class AnimationEventDispatcher : MonoBehaviour
{
    public UnityAnimationEvent OnAnimationComplete;

    public AnimationEventDispatcher(Animator animator, List<Ability> abilities)
    {
        BindAnimationAbilities(animator, abilities);
    }

    public void BindAnimationAbilities(Animator animator, List<Ability> abilities)
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            for (int j = 0; j < animator.runtimeAnimatorController.animationClips.Length; j++)
            {
                AnimationClip clip = animator.runtimeAnimatorController.animationClips[j];
                if(animator.GetBehaviours(animator.runtimeAnimatorController).animationClips.)
                if (!clip.name.Contains("Idle") && clip.name.Contains(abilities[i].Base.Name))
                {
                    AnimationEvent animationEndEvent = new AnimationEvent();
                    animationEndEvent.time = clip.length;
                    animationEndEvent.functionName = "AnimationCompleteHandler";
                    animationEndEvent.intParameter = i;
                    clip.AddEvent(animationEndEvent);
                    break;
                }
            }
        }
    }


    public void AnimationCompleteHandler(int Ability)
    {
        Debug.Log($"{name} animation complete.");
        OnAnimationComplete?.Invoke(Ability);
    }
}
