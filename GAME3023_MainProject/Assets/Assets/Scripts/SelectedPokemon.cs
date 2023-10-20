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
    public float AnimationSpeed = 0.03f;
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
            CurrentImage.sprite = Spokemon.GetSprite();
            CurrentImage.rectTransform.sizeDelta = CurrentImage.sprite.texture.Size();
            CurrentImage.rectTransform.localScale = CurrentImage.rectTransform.localScale * 4;
            DisplayedName.text = Spokemon.getname();



            if (!IsAlly)
            {
                CurrentImage.rectTransform.position = CurrentImage.rectTransform.position + new Vector3(0, 0, 0);

            }
            else
            {
                if(Spokemon.getname()=="waspius") 
                {
                    CurrentImage.rectTransform.Rotate(0, 180, 0);

                }
                CurrentImage.rectTransform.position = CurrentImage.rectTransform.position - new Vector3(50, 0, 0);
            }
            if (PokemonPngs.Count > 1)
            {
                PokemonPngs = Spokemon.getAnimation(0);

                PlayUIAnim();
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
    public void RevertAnimation()
    {
        StartCoroutine(Return());
    }


    public void SetPokemonPngs(List<Sprite> sprites)
    {
        PokemonPngs = sprites;
    }

    public void Rotate()
    {

        StartCoroutine(Rotation());
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
    IEnumerator Rotation(float time =4.0f)
    {

        yield return new WaitForSeconds(time/2);
        CurrentImage.rectTransform.Rotate(0, 180, 0);
        yield return new WaitForSeconds(time/2);

        CurrentImage.rectTransform.Rotate(0, -180, 0);

    }

    IEnumerator Return(float time = 2.0f, int state=0)
    {
        yield return new WaitForSeconds(time);
        SetPokemonPngs(Spokemon.getAnimation(state));

    }

    // Update is called once per frame
    void Update()
    {


    }
}
