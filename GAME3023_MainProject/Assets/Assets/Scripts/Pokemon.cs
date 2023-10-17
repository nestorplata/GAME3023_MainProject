using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class Pokemon : MonoBehaviour
{
    int Life;
    int Attack;
    int Defense;
    int Evasion;
    int fortification=1;
    string Pname;
    string[] Abilities;
    string[] TextInformation;
    List<string> States;


    List<List<Sprite>> Animations;
    // Start is called before the first frame update

    public Pokemon(string name, string[] abilities,
        string[] Text, List<string> states, int[] stats,
         List<List<Sprite>> animations)
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
        Animations = animations;
    }
    public Pokemon()
    {
        Pname = "generalPokemon";
        Abilities = new string[5];
        TextInformation = new string[5];
        States = new List<string>();
        Life = 1;
        Attack = 1;
        Defense = 1;
        Evasion = 1;
        Animations = null;


    }
    public int getlife()
    {
        return Life;
    }
    public string getname()
    {
        return Pname;
    }
    public string getabilities(int i = 1)
    {
        if (Abilities.Length > i)
            return Abilities[i];
        else return null;
    }
    public string gettext(int i=1)
    {
        if(TextInformation.Length > i)
            return TextInformation[i];
        else return null;
    }
    public List<string> getstates()
    {
        return States;
    }

    public Sprite GetSprite()
    {
        return getAnimation()[0];
    }
    public List<Sprite> getAnimation(int i  = 0)
    {
        return Animations[i];


    }
    public void SetFortification(int i)
    {
        
        fortification = fortification +i;
        if (fortification > 2)
        {
            fortification = 2;
        }
        if (fortification < 0)
            fortification = 0;
    }
    public int GetFortification()
    {

       return fortification;
    }

}
