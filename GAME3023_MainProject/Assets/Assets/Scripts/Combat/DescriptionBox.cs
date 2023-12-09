using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionBox : MonoBehaviour
{
    // Start is called before the first frame update
    int ChoosenAbility;
    Text explanation;
    public void Setup()
    {
        explanation = transform.GetComponentInChildren<Text>();
    }

    // Update is called once per frame


    public void SetChoosenAbility(int chosen)
    {
        ChoosenAbility = chosen;
        Debug.Log(ChoosenAbility);

    }
    public void SetText(string text)
    {
        explanation.text = text;
    }
}
