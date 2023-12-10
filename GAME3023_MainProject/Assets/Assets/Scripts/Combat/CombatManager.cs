using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] DescriptionBox DescriptionBox;
    [SerializeField] List<UIButtonsCombat> AbilityButtons;


    private void Start()
    {
        SetupBattle();
    }

     
    public void SetupBattle()
    {
        PlayerUnit.Setup();
        EnemyUnit.Setup();
        DescriptionBox.Setup("Combat Started");

        for (int i = 0;i< AbilityButtons.Count; i++)
        {
            var Button = AbilityButtons[i];
            Button.Setup(i, AbilityChoosen, SetDescriptionBoxText);
            Button.SetName(PlayerUnit.Pokemon.Abilities[i].Base.Name);            
            PlayerUnit.AbilityChoosenDelegate += Button.DisableForTime;

        }

    }

    public void AbilityChoosen(int Ability)
    {
        string message = PlayerUnit.Base.Name + " used " + PlayerUnit.GetAbilityBase(Ability).Name;
        DescriptionBox.SetText(message);
        PlayerUnit.PlayAbility(Ability);
        PlayerUnit.AbilityChoosenDelegate();
        
    }

    public void SetDescriptionBoxText(int Ability)
    {
        DescriptionBox.SetText(PlayerUnit.GetAbilityBase(Ability).description);
    }

}







