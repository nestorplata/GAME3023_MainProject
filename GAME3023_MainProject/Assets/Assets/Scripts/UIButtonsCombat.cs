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

    Button UIButton;
    CombatManager manager;
    Pokemon pokemon;
    TextBoxBehaviur TextBlock;


    Vector3 OriginalSize;
    

    // Start is called before the first frame update
    void Start()
    {
        TextBlock = GameObject.Find("Text Screen").GetComponent<TextBoxBehaviur>();

        UIButton = GetComponent<Button>();
        manager = gameObject.transform.parent.GetComponentInParent<CombatManager>();
        pokemon = manager.GetPokemon(true);

        OriginalSize = transform.localScale;

        Text text = gameObject.transform.GetChild(0).GetComponent<Text>();
        text.text = pokemon.getabilities(AbilityNum);
        coroutine = ReturnSize(1.0f);

        //Checkin no other button has been pressed

    }

    public void OnMousePressed()
    {
        if (!IsPressed)
        {
            transform.localScale = OriginalSize * 3 / 4;
            TextBlock.SetChoosenAbility(AbilityNum);
            TextBlock.SetText(pokemon.getname() +" used "+pokemon.getabilities(AbilityNum));

            foreach (Button button in FindObjectsOfType<Button>())
            {
                button.GetComponent<Button>().GetComponent<UIButtonsCombat>().AbilityChoseen();
            } 
        }
    }
    
    public void AbilityChoseen()
    {
        StartCoroutine(ReturnSize(2.0f));

    }
    // Update is called once per frame

    IEnumerator ReturnSize(float waitTime)
    {
        UIButton.interactable = false;
        yield return new WaitForSeconds(waitTime);
        UIButton.interactable = true;
        transform.localScale = OriginalSize;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(UIButton.interactable)
            TextBlock.SetText(pokemon.gettext(AbilityNum));

    }


}
