using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

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
        DescriptionBox.Setup();
        //for each
    }

}







