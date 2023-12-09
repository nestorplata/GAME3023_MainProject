using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName ="Pokemon/Create new Ability")]
public class AbilityBase : ScriptableObject
{
    [SerializeField] string Name;

    [TextArea]
    [SerializeField] string description;
}
