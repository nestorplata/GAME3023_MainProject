using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class UIButtonsCombat : MonoBehaviour, IPointerEnterHandler
{

    Button UIButton;
    Text Text;
    Vector3 OriginalSize;

    public delegate void GetAbilityDelegate(BattleUnit unit,int Ability);
    GetAbilityDelegate OnclickDelegate;
    GetAbilityDelegate OnHooverDelegate;

    BattleUnit AlliedUnit;
    int AbilityNum;

    public void Setup(BattleUnit unit, int index)
    {
        UIButton = GetComponent<Button>();
        Text = GetComponentInChildren<Text>();
        OriginalSize = transform.localScale;
        AlliedUnit = unit;
        AbilityNum = index;

    }

    public void SetDelegates(GetAbilityDelegate Click, GetAbilityDelegate Hoovering)
    {
        OnclickDelegate = Click;
        OnHooverDelegate = Hoovering;
    }

    public void SetName(string name)
    {
        Text.text = name;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (UIButton.interactable)
        {
            OnMouseHoovered();
        }

    }

    public void OnMousePressed()
    {
        transform.localScale = OriginalSize * 3 / 4;
        OnclickDelegate(AlliedUnit, AbilityNum);
    }

    public void OnMouseHoovered()
    {
        OnHooverDelegate(AlliedUnit, AbilityNum);
    }

    public void DisableOnClick()
    {
        StartCoroutine(ReturnSize(4.0f));
    }

    public void EnableOnTurnEnd()
    {
        UIButton.interactable = true;
    }


    IEnumerator ReturnSize(float waitTime)
    {

        UIButton.interactable = false;
        yield return new WaitForSeconds(waitTime / 2);
        transform.localScale = OriginalSize;

    }

}
