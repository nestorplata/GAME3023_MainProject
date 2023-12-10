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
        Abilities = new List<Ability>();
        foreach (var Base in Base.AbilitiesBases) 
        {
            Abilities.Add(new Ability(Base));
        }
        HP = Base.MaxHP;
    }



}
