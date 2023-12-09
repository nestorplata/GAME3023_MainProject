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

        SetHPBar((float)pokemon.HP / pokemon.Base.MaxHP);
        HPAmount.text = pokemon.HP + "/" + pokemon.Base.MaxHP;
    }

    public void SetHPBar( float normalizedHP)
    {
        HPBar.transform.localScale = new Vector3(normalizedHP, 1f);
    }

}
