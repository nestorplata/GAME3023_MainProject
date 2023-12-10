using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonsCombat : MonoBehaviour, IPointerEnterHandler
{
    int AbilityNum;
    Button UIButton;
    Text Text;

    Vector3 OriginalSize;

    public delegate void GetAbilityDelegate(int Ability);
    GetAbilityDelegate OnclickDelegate;
    GetAbilityDelegate OnHooverDelegate;

    public void Setup(int index, GetAbilityDelegate Click, GetAbilityDelegate Hoovering)
    {
        UIButton = GetComponent<Button>();
        Text = GetComponentInChildren<Text>();
        OriginalSize = transform.localScale;

        AbilityNum = index;
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
        OnclickDelegate(AbilityNum);
    }

    public void OnMouseHoovered()
    {
        OnHooverDelegate(AbilityNum);
    }

    public void DisableForTime(float time)
    {
        StartCoroutine(ReturnSize(time));
    }

    public void ToogleInteractibity()
    {

    }


    IEnumerator ReturnSize(float waitTime)
    {

        UIButton.interactable = false;
        yield return new WaitForSeconds(waitTime / 2);
        UIButton.interactable = true;
        transform.localScale = OriginalSize;

    }

}
