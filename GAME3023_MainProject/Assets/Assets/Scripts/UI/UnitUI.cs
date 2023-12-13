using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class UnitUI : MonoBehaviour
{
    [SerializeField] Image HPBar;
    [SerializeField] Text DisplayedName;
    [SerializeField] Text HPAmount;

    public void SetData(Pokemon pokemon)
    {
        DisplayedName.text = pokemon.Base.name;
        SetHPBar(pokemon);
    }


    public void SetHPBar( Pokemon pokemon)
    {
        if(pokemon.HP>0)
        {
            HPBar.transform.localScale = new Vector3((float)pokemon.HP / pokemon.Base.MaxHP, 1f);
            HPAmount.text = pokemon.HP + "/" + pokemon.Base.MaxHP;
        }
        else
            {
            HPBar.transform.localScale = new Vector3(0, 1f);
            HPAmount.text = 0 + "/" + pokemon.Base.MaxHP;
        }


    }

}
