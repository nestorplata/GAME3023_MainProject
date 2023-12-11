using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] public PokemonBase Base;
    [SerializeField] UnitUI StatsHUD;
    [SerializeField] bool isPlayerUnit;
    public Pokemon Pokemon { get; set; }
    public AnimationEventDispatcher AnimationEvents { get; set; }


    public delegate void MultiDelegate();
    public MultiDelegate AbilityChoosenDelegate;

    public class UnityAnimationEvent : UnityEvent<string> { };
    public UnityAnimationEvent OnAnimationStart;
    public UnityAnimationEvent OnAnimationComplete;

    Animator animator;


    public void Setup()
    {
        animator = GetComponent<Animator>();
        AnimationEvents = new AnimationEventDispatcher(animator, Pokemon.Abilities);
        animator.runtimeAnimatorController = Base.animatorController;
        animator.speed = 0.1f;

        Pokemon = new Pokemon(Base);
        StatsHUD.SetData(Pokemon);
    }

    public AbilityBase GetAbilityBase(int Ability)
    {
        return Pokemon.Abilities[Ability].Base;
    }

    internal void PlayAbility(int ability)
    {
        string Clipname = SearchForClip(GetAbilityBase(ability).Name);
        if (Clipname != "")
        {
            animator.Play(Clipname);
        }
    }

    public string SearchForClip(AbilityType name)
    {
        foreach (var clip in Base.animatorController.animationClips)
        {
            if (clip.name.Contains(name))
            {
                return clip.name;
            }
        }
        foreach (var clip in Base.animatorController.animationClips)
        {
            if (clip.name.Contains("General"))
            {
                return clip.name;
            }
        }
        return "";
    }
}
