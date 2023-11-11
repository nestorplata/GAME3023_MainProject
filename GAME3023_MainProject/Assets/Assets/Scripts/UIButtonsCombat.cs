using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonsCombat : MonoBehaviour, IPointerEnterHandler
{
    
    public bool IsPressed;
    public int AbilityNum;
    private IEnumerator coroutine;
    public int random;

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
        manager = GetComponentInParent<CombatManager>();
        TextBlock = GameObject.Find("Text Screen").GetComponent<TextBoxBehaviur>();
        AllyInformation = GameObject.Find("APokemon").GetComponent<SelectedPokemon>();
        EnemyInformation = GameObject.Find("EPokemon").GetComponent<SelectedPokemon>();
        UIButton = GetComponent<Button>();

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

            foreach (Button button in FindObjectsOfType<Button>())
            {
                button.GetComponent<Button>().GetComponent<UIButtonsCombat>().AbilityChoseen();

            }

            AllyInformation.OnTurn(AbilityNum);

            
            EnemyInformation.AfterTurn(AbilityNum);



        }
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (UIButton.interactable)
            TextBlock.SetText(Apokemon.gettext(AbilityNum));

    }

    public void AbilityChoseen(float value=4.0f)
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
