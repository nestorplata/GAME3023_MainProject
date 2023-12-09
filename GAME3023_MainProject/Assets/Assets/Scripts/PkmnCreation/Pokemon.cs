using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{

    public PokemonBase Base { get; set; }
    public List<Ability> Abilities { get; set; }
    public int HP { get; set; }

    public Pokemon (PokemonBase @base)
    {
        Base = @base;
        //change to max HP
        HP = Base.MaxHP;
    }
}
