using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class BattleUnit : MonoBehaviour
{
    [SerializeField] public PokemonBase Base;
    [SerializeField] UnitUI StatsHUD;
    [SerializeField] bool isPlayerUnit;
    Animator animator;

    public Pokemon Pokemon { get; set; }

    public delegate void MultiDelegate();
    public delegate void SimpleDelegate(string name);


    public AnimationEventDispatcher AnimationDispatcher { get; set; }

    public SimpleDelegate OnAnimationComplete;


    public void Setup()
    {
        animator = GetComponent<Animator>();
        Pokemon = new Pokemon(Base);

        animator.runtimeAnimatorController = Base.animatorController;
        animator.speed = 0.1f;

        OnAnimationComplete = AnimationCompleteHandler;
        AnimationDispatcher = new AnimationEventDispatcher(animator, Pokemon.Abilities);
        StatsHUD.SetData(Pokemon);
    }

    public AbilityBase GetAbilityBase(int index)
    {
        return Pokemon.Abilities[index].Base;
    }

    internal void PlayAbility(int index)
    {

        Debug.Log(isPlayerUnit +","+Pokemon.Abilities[index].StateName);
        animator.Play(Pokemon.Abilities[index].StateName);
    }

    public void StopaAbility()
    {
        animator.Play(AnimationDispatcher.IdleAnimation.StateName);
    }

    public void AnimationCompleteHandler(string name)
    {
        Debug.Log($"{name} animation complete.");
        OnAnimationComplete(name);
    }

}
