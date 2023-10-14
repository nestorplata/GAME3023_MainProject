using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPokemon : MonoBehaviour
{
    public bool IsAlly;
    public List<Sprite> PokemonPngs;

    Image CurrentImage;
    CombatManager manager;
    Pokemon Spokemon;
    // Start is called before the first frame update
    void Start()
    {
        CurrentImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        manager = gameObject.transform.parent.GetComponentInParent<CombatManager>();
        Spokemon = new Pokemon();
        setPokemonImage();

    }
    
    void setPokemonImage()
    {
        if (manager)
        {
            Spokemon = manager.GetPokemon(IsAlly);
            string name = Spokemon.getname();
            Debug.Log(name);
            
            //CurrentImage.rectTransform.sizeDelta = new Vector2(100, 50);
            CurrentImage.rectTransform.position = CurrentImage.rectTransform.position - new Vector3(50, 50, 0);
            if (name == "waspius")
            {
                CurrentImage.sprite = PokemonPngs[1];
                CurrentImage.rectTransform.position = CurrentImage.rectTransform.position - new Vector3(0, 50, 0);
                CurrentImage.rectTransform.Rotate(0, 180, 0);

                CurrentImage.rectTransform.localScale = CurrentImage.rectTransform.localScale * 3;
            }
            else
            {
                CurrentImage.sprite = PokemonPngs[0];
                CurrentImage.rectTransform.position = CurrentImage.rectTransform.position - new Vector3(0, 50, 0);

                CurrentImage.rectTransform.localScale = CurrentImage.rectTransform.localScale * 3;


            }
            CurrentImage.rectTransform.sizeDelta = CurrentImage.sprite.texture.Size();

        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
