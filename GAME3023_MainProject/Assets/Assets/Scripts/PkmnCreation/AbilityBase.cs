using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName ="Pokemon/Create new Ability")]
public class AbilityBase : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public AbilityType Type;
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
