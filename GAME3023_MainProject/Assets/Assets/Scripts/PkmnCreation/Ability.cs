using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public AbilityBase Base { get; set; }
    public string StateName { get; set; }

    public Functionality Functionality { get; set; }

    public Ability(AbilityBase @Base)
    {
        this.Base = @Base;

    }
}
