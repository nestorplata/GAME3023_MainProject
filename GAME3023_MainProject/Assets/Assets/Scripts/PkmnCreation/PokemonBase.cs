using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Animations;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

[CreateAssetMenu(fileName = "Pokemons", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public int MaxHP = 1;
    [SerializeField] public int Attack = 1;
    [SerializeField] public int Defense = 1;
    [SerializeField] public int Speed = 1;
    [SerializeField] AnimatorController animatorController;
    [SerializeField] List<AbilityBase> Abilities;

    [TextArea]
    [SerializeField] string Description;

}

public enum PokemonAnimation
{
    Idle1,
    Idle2,
    Idle3,
    Attack1,
    Attack2, 
    Defeat,
    Pause
}




