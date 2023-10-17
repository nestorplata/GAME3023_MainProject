using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEngine.UIElements.UxmlAttributeDescription;
//using UnityEngine.UIElements;

public class UIButtonsCombat : MonoBehaviour, IPointerEnterHandler
{
    
    public bool IsPressed;
    public int AbilityNum;
    private IEnumerator coroutine;

    CombatManager manager;

    SelectedPokemon AllyInformation;
    SelectedPokemon EnemyInformation;

    Pokemon Apokemon;
    Pokemon Epokemon;


    Button UIButton;
    TextBoxBehaviur TextBlock;

    
    Vector3 OriginalSize;

    // Start is called before the first frame update
    void Start()
    {
        TextBlock = GameObject.Find("Text Screen").GetComponent<TextBoxBehaviur>();
        AllyInformation = GameObject.Find("APokemon").GetComponent<SelectedPokemon>();
        EnemyInformation = GameObject.Find("EPokemon").GetComponent<SelectedPokemon>();


        UIButton = GetComponent<Button>();
        manager = gameObject.transform.parent.GetComponentInParent<CombatManager>();
        Apokemon = manager.GetPokemon(true);
        Epokemon = manager.GetPokemon(false);

        OriginalSize = transform.localScale;

        Text text = gameObject.transform.GetChild(0).GetComponent<Text>();
        text.text = Apokemon.getabilities(AbilityNum);
        coroutine = ReturnSize(4.0f);

        //Checkin no other button has been pressed

    }

    public void OnMousePressed()
    {
        if (!IsPressed)
        {
            transform.localScale = OriginalSize * 3 / 4;
            TextBlock.SetChoosenAbility(AbilityNum);
            TextBlock.SetText(Apokemon.getname() +" used "+Apokemon.getabilities(AbilityNum));
            EnemyInformation.Rotate();

            foreach (Button button in FindObjectsOfType<Button>())
            {
                button.GetComponent<Button>().GetComponent<UIButtonsCombat>().AbilityChoseen();

            }
            switch(AbilityNum)
            {
                case 2:
                    Apokemon.SetFortification(1);
                    break;
                case 4:
                    Apokemon.SetFortification(-1);
                    break;


            }
            switch (Apokemon.GetFortification())
            {
                case 0:
                    AllyInformation.SetPokemonPngs(Apokemon.getAnimation(2));
                    //AllyInformation.Rotate();
                    break;
                case 1:
                    AllyInformation.SetPokemonPngs(Apokemon.getAnimation(0));
                    break;
                case 2:
                    AllyInformation.SetPokemonPngs(Apokemon.getAnimation(1));
                    break;
            }

        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (UIButton.interactable)
            TextBlock.SetText(Apokemon.gettext(AbilityNum));

    }

    public void AbilityChoseen(float value=5.0f)
    {
        UIButton.interactable = false;
        //Debug.Log("AnimationChanged to" + AbilityNum);
        StartCoroutine(ReturnSize(value));

    }
    // Update is called once per frame

    IEnumerator ReturnSize(float waitTime)
    {
        yield return new WaitForSeconds(waitTime/2);
        TextBlock.SetText(Epokemon.getname() + " used " + Epokemon.getabilities(5));

        yield return new WaitForSeconds(waitTime / 2);
        UIButton.interactable = true;
        transform.localScale = OriginalSize;

    }

}
