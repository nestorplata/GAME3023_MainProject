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

    // Start is called before the first frame update
    //void Start()
    //{
    //    UIButton = GetComponent<Button>();

    //    OriginalSize = transform.localScale;
    //}

    //public void OnMousePressed()
    //{
    //    if (!IsPressed)
    //    {
    //        transform.localScale = OriginalSize * 3 / 4;
    //        DescritpionBlock.SetChoosenAbility(AbilityNum);
    //        //DescritpionBlock.SetText(Apokemon.getname() +" used "+Apokemon.getabilities(AbilityNum));

    //        foreach (Button button in FindObjectsOfType<Button>())
    //        {
    //            button.GetComponent<Button>().GetComponent<UIButtonsCombat>().AbilityChoseen();
    //        }
    //    }
    //}


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
    //    //if (UIButton.interactable)
    //        //DescritpionBlock.SetText(Apokemon.gettext(AbilityNum));

    }

    //public void AbilityChoseen(float value=4.0f)
    //{
    //    UIButton.interactable = false;
    //    StartCoroutine(ReturnSize(value));

    //}

    //IEnumerator ReturnSize(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime/2);
    //    //DescritpionBlock.SetText(Epokemon.getname() + " used " + Epokemon.getabilities(5));

    //    yield return new WaitForSeconds(waitTime / 2);
    //    UIButton.interactable = true;
    //    transform.localScale = OriginalSize;

    //}

}
