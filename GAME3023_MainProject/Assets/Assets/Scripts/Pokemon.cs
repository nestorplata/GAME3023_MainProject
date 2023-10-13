using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Pokemon : MonoBehaviour
{
    int Life;
    int Attack;
    int Defense;
    int Evasion;
    string Pname;
    string[] Abilities;
    string[] TextInformation;
    List<string> States;

    // Start is called before the first frame update

    public Pokemon( string name, string[] abilities,
        string[] Text, List<string> states, int[] stats)
    {
        Pname = name;
        Abilities = abilities;
        TextInformation = Text;
        States = states;
        Life = stats[0];
        Attack = stats[1];
        Defense = stats[2];
        Evasion = stats[3];
        Abilities = abilities;


    }
    public Pokemon()
    {
        Pname = "generalPokemon";
        Abilities = new string[4];
        TextInformation = new string[4];
        States = new List<string>();
        Life = 1;
        Attack = 1;
        Defense = 1;
        Evasion = 1;


    }

}
