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

        for (int i = 0; i < AbilityButtons.Count; i++)
        {
            var Button = AbilityButtons[i];
            Button.Setup(PlayerUnit, i);
            Button.SetName(PlayerUnit.Pokemon.Abilities[i].Base.Name);
            Button.SetDelegates(playerTurn, SetDescriptionBoxText);
        }
        PlayerUnit.OnAnimationComplete=OnPlayerAnimationEnded;
        EnemyUnit.OnAnimationComplete=OnEnemyAnimationEnded;

    }

    public void playerTurn(BattleUnit Unit, int Ability)
    {
        foreach (var button in AbilityButtons)
        {
            button.DisableButton();
        }
        AbilityChoosen(Unit, Ability);
    }

    public void AbilityChoosen( BattleUnit Unit, int Ability)
    {
        string message = Unit.Base.Name + " used " + Unit.GetAbilityBase(Ability).Name;
        DescriptionBox.SetText(message);
        Unit.PlayAbility(Ability);
    }

    public void OnPlayerAnimationEnded(string name)
    {
        PlayerUnit.StopaAbility();
        int randomNumber = Random.Range(0, 3);
        AbilityChoosen(EnemyUnit, randomNumber);
    }

    public void OnEnemyAnimationEnded(string name)
    {
        EnemyUnit.StopaAbility();
        foreach (var button in AbilityButtons)
        {
            button.OnEnemyTurnEnd();
        }
    }

    public void SetDescriptionBoxText(BattleUnit Unit, int Ability)
    {
        DescriptionBox.SetText(Unit.GetAbilityBase(Ability).description);
    }

}







