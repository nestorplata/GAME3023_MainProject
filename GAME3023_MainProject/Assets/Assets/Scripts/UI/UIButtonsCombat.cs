using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonsCombat : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] int AbilityNum;
    Button UIButton;
    Vector3 OriginalSize;

    public delegate void GetAbilityDelegate(int Ability);
    GetAbilityDelegate OnclickDelegate;
    GetAbilityDelegate OnHooverDelegate;

    public void Setup(GetAbilityDelegate Click, GetAbilityDelegate Hoovering)
    {
        UIButton = GetComponent<Button>();
        OriginalSize = transform.localScale;
        OnclickDelegate = Click;
        OnHooverDelegate = Hoovering;
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
        Debug.Log(AbilityNum);
        OnclickDelegate(AbilityNum);
    }

    public void OnMouseHoovered()
    {
        Debug.Log(AbilityNum);
        OnHooverDelegate(AbilityNum);
    }

    public void DisableForTime(float time)
    {
        StartCoroutine(ReturnSize(time));

    }


    IEnumerator ReturnSize(float waitTime)
    {

        UIButton.interactable = false;
        yield return new WaitForSeconds(waitTime / 2);
        UIButton.interactable = true;
        transform.localScale = OriginalSize;

    }

}
