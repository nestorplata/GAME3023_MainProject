using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonsCombat : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] DescriptionBox DescritpionBlock;

    public bool IsPressed;
    public int AbilityNum;
    //public int random;


    Pokemon Apokemon;

    //[SerializeField] AbilityBase AbilityBase;
    Ability Ability;

    Button UIButton;

    Vector3 OriginalSize;



    public void OnMousePressed()
    {
        if (!IsPressed)
        {
            StartCoroutine(ReturnSize(4.0f));
            //DescritpionBlock.SetChoosenAbility(AbilityNum);
            //DescritpionBlock.SetText(Apokemon.getname() +" used "+Apokemon.getabilities(AbilityNum));
          //foreach (Button button in FindObjectsOfType<Button>())
            //{
            //    button.GetComponent<Button>().GetComponent<UIButtonsCombat>().AbilityChoseen();
            //}
        }
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
    //    //if (UIButton.interactable)
    //        //DescritpionBlock.SetText(Apokemon.gettext(AbilityNum));

    }


    IEnumerator ReturnSize(float waitTime)
    {
        OriginalSize = transform.localScale;
        transform.localScale = OriginalSize * 3 / 4;
        UIButton.interactable = false;
        yield return new WaitForSeconds(waitTime / 2);
        UIButton.interactable = true;
        transform.localScale = OriginalSize;

    }

}
