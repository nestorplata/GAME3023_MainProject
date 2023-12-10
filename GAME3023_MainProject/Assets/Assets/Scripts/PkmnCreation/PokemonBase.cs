using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


[CreateAssetMenu(fileName = "Pokemons", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public int MaxHP = 1;
    [SerializeField] public int Attack = 1;
    [SerializeField] public int Defense = 1;
    [SerializeField] public int Speed = 1;
    [SerializeField] public RuntimeAnimatorController animatorController;
    [SerializeField] public List<AbilityBase> AbilitiesBases;

    [TextArea]
    [SerializeField] string Description;

}
