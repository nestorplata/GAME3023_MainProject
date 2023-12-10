using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] public PokemonBase Base;
    [SerializeField] UnitUI StatsHUD;
    [SerializeField] bool isPlayerUnit;

    public delegate void MultiDelegate(float time = 4.0f);
    public MultiDelegate AbilityChoosenDelegate;
    Animator animator;


    public Pokemon Pokemon { get; set; }

    public void Setup()
    {
        animator = GetComponent<Animator>();
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

    public string SearchForClip(string name)
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
