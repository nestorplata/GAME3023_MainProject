using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName ="Pokemon/Create new Ability")]
public class AbilityBase : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public AbilityType Type;
    [SerializeField] public FunctionalityType FunctionalityType;

    [TextArea]
    [SerializeField] public string description;
}

public enum AbilityType
{
    General,
    Attack,
    Special,
    Death,
    Idle,
    Hurt,
}

public enum FunctionalityType
{
    Attack,
    Heal,
    SpecialAttack,
    Escape,
    Struggle

}


