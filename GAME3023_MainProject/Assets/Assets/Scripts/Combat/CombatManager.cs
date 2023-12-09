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

    delegate void MultiDelegate(float time =4.0f);
    MultiDelegate AbilityChoosenDelegate;


    private void Start()
    {
        SetupBattle();
    }

     
    public void SetupBattle()
    {
        PlayerUnit.Setup();
        EnemyUnit.Setup();
        DescriptionBox.Setup("");

        foreach (var Button in AbilityButtons)
        {
            Button.Setup(AbilityChoosen, SetDescriptionBoxText);
            AbilityChoosenDelegate += Button.DisableForTime;
        }
    }

    public void AbilityChoosen(int Ability)
    {
        AbilityChoosenDelegate();
    }
    public void SetDescriptionBoxText(int Ability)
    {
        DescriptionBox.SetText(PlayerUnit.GetAbilityDescription(Ability));
    }
}







