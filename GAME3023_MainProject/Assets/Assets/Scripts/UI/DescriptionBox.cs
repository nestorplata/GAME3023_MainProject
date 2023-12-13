using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionBox : MonoBehaviour
{
    Text explanation;

    public void Setup(string StartingMessage)
    {
        explanation =GetComponentInChildren<Text>();
        SetText(StartingMessage);
    }
    public void SetText(string text)
    {
        explanation.text = text;
    }
    public void SetAbilityText(BattleUnit Unit, int Ability)
    {
        SetText(Unit.GetAbilityBase(Ability).description);
    }
}
