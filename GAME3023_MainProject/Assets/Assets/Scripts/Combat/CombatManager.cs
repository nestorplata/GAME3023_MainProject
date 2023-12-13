using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CombatManager : MonoBehaviour
{
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] DescriptionBox DescriptionBox;
    [SerializeField] SceneToogler SceneToogler;
    [SerializeField] List<UIButtonsCombat> AbilityButtons;

    private AbilityFunctionality AbilityFunctionality;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        PlayerUnit.Setup();
        EnemyUnit.Setup();
        DescriptionBox.Setup("Combat Started");

        AbilityFunctionality = new AbilityFunctionality(SceneToogler);
        AbilityFunctionality.AssignFuntionalities(PlayerUnit);
        AbilityFunctionality.AssignFuntionalities(EnemyUnit);

        for (int i = 0; i < AbilityButtons.Count; i++)
        {
            var Button = AbilityButtons[i];
            Button.Setup(PlayerUnit, i);
            Button.SetName(PlayerUnit.Pokemon.Abilities[i].Base.Name);
            Button.SetDelegates(OnPlayerAbilityChosen, DescriptionBox.SetAbilityText);
        }
        PlayerUnit.OnAnimationComplete=OnPlayerAnimationEnded;
        EnemyUnit.OnAnimationComplete= OnEnemyAnimationEnded;

    }

    public void OnPlayerAbilityChosen(BattleUnit Unit, int Ability)
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
        OnAnimationEnded(PlayerUnit, EnemyUnit, name);
        StartCoroutine(AllowEnemyTurn(2.0f));
    }

    public void OnEnemyAnimationEnded(string name)
    {
        OnAnimationEnded(EnemyUnit, PlayerUnit, name);
        StartCoroutine(AllowPlayerTurn(2.0f));
    }

    IEnumerator AllowEnemyTurn(float time)
    {

        yield return new WaitForSeconds(time);
        if (!CheckForEnd())
        {
            int randomNumber = Random.Range(0, 1);
            AbilityChoosen(EnemyUnit, randomNumber);
        }
    }

    IEnumerator AllowPlayerTurn(float time)
    {
        yield return new WaitForSeconds(time);

        if (!CheckForEnd())
        {
            foreach (var button in AbilityButtons)
            {
                button.EnableButton();
            }
        }
    }

    public void OnAnimationEnded(BattleUnit Actor, BattleUnit Reactor, string Name)
    {
        Actor.StopaAbility();
        bool isSuccessfull = Actor.GetAbility(Name).Functionality(Actor, Reactor);
        string message = Actor.GetAbility(Name).Base.Name;

        if (isSuccessfull)
        {
            DescriptionBox.SetText("Succesfull " + message);
        }
        else
        {
            DescriptionBox.SetText("Failed " + message);
        }

        Actor.UpdateHPStats();
        Reactor.UpdateHPStats();

    }

    public bool CheckForEnd()
    {
        if (PlayerUnit.Pokemon.HP <= 0)
        {
            SceneToogler.MoveToScene(5);
            PlayerUnit.PlayDead();
            return true;
        }
        else if (EnemyUnit.Pokemon.HP <= 0)
        {
            SceneToogler.CheckForSave(1);
            EnemyUnit.PlayDead();
            return true;
        }
        return false;
    }




}







