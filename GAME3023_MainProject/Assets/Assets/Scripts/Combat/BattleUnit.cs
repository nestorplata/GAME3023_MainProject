using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase Base;
    [SerializeField] UnitUI StatsHUD;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    public void Setup()
    {
        Pokemon = new Pokemon(Base);
        StatsHUD.SetData(Pokemon);
    }

    public string GetAbilityDescription(int Ability)
    {
        return Pokemon.Abilities[Ability].Base.description;
    }
}
