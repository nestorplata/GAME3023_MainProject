using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPokemon : MonoBehaviour
{
    public List<Sprite> PokemonPngs;
    public bool IsAlly;
    public float AnimationSpeed = 0.5f;
    private int IndexSprite;

    CombatManager manager;
    Pokemon Spokemon;
    Image CurrentImage;
    Text DisplayedName;

    Coroutine CorotineAnim;
    bool IsDone;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.transform.parent.GetComponentInParent<CombatManager>();
        Spokemon = new Pokemon();
        CurrentImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        DisplayedName = transform.GetChild(1).GetComponent<Text>();
        setPokemonImage();

    }
    
    void setPokemonImage()
    {
        if (manager)
        {
            Spokemon = manager.GetPokemon(IsAlly);
            PokemonPngs = Spokemon.getAnimation();
            if(PokemonPngs.Count > 1)
            {
                PlayUIAnim();
            }
            CurrentImage.rectTransform.position = CurrentImage.rectTransform.position - new Vector3(50, 100, 0);
            CurrentImage.rectTransform.localScale = CurrentImage.rectTransform.localScale * 3;
            CurrentImage.rectTransform.sizeDelta = CurrentImage.sprite.texture.Size();
            DisplayedName.text = Spokemon.getname();
            if (!IsAlly)
            {
                CurrentImage.rectTransform.Rotate(0, 180, 0);
            }

        }
    }



    public void PlayUIAnim()
    {
        IsDone = false;
        StartCoroutine(Func_PlayAnimUI());
    }

    public void StopUIAnim()
    {
        IsDone = true;
        StopCoroutine(Func_PlayAnimUI());
    }
    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(AnimationSpeed);
        if (IndexSprite >= PokemonPngs.Count)
        {
            IndexSprite = 0;
        }
        CurrentImage.sprite = PokemonPngs[IndexSprite];
        IndexSprite += 1;
        if (IsDone == false)
            CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }
    // Update is called once per frame
    void Update()
    {
    }
}
