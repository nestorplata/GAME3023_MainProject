using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName ="Pokemon/Create new Ability")]
public class AbilityBase : ScriptableObject
{
    [SerializeField] public string Name;
    [TextArea]
    [SerializeField] public string description;



}

