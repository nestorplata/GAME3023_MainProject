using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public AbilityBase Base { get; set; }
    //public delegate void Effect();

    public Ability(AbilityBase @Base)
    {
        this.Base = @Base;
    }



}
