using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate bool Functionality(BattleUnit Dealer, BattleUnit Reciever);

public class AbilityFunctionality : MonoBehaviour
{
    SceneToogler SceneToogler;

    public AbilityFunctionality(SceneToogler sceneToogler)
    {
        SceneToogler = sceneToogler;
    }

    public void AssignFuntionalities(BattleUnit Unit)
    { 
        foreach(var Ability in Unit.Pokemon.Abilities)
        {
            switch(Ability.Base.FunctionalityType)
            {
                case FunctionalityType.Attack:
                    Ability.Functionality = Attack; 
                    break;
                case FunctionalityType.Struggle:
                    Ability.Functionality = Struggle;
                    break;
                case FunctionalityType.Escape:
                    Ability.Functionality = Escape;
                    break;
                case FunctionalityType.SpecialAttack:
                    Ability.Functionality = SpecialAttack;
                    break;
            }

        }
    }

    public bool Attack(BattleUnit Dealer, BattleUnit Reciever)
    {      
        int AttackValue= Dealer.Pokemon.Base.Attack;
        Reciever.Pokemon.HP -= AttackValue - (AttackValue * Reciever.Pokemon.Base.Defense) / 100;
        Debug.Log("Attack "+ AttackValue);
        return true;
    
    }

    public bool Struggle(BattleUnit Dealer, BattleUnit Reciever)
    {
        int RandomNumber = Random.Range(0, 100);
        Debug.Log("Struggle " + RandomNumber);

        if (RandomNumber>90)
        {
            Reciever.Pokemon.HP =0;
            return true;

        }
        return false;

    }

    public bool Escape(BattleUnit Dealer, BattleUnit Reciever)
    {
        int RandomNumber = Random.Range(0, 100);
        Debug.Log("Escape " + RandomNumber);
        if (RandomNumber>10)
        {
            SceneToogler.CheckForSave(1);
            return true;
        }
        return false;
    }

    public bool SpecialAttack(BattleUnit Dealer, BattleUnit Reciever)
    {
        int AttackValue = Dealer.Pokemon.Base.Attack;
        Debug.Log("SpecialAttack " + AttackValue);

        Reciever.Pokemon.HP -= AttackValue*2;
        return true;

    }

}
