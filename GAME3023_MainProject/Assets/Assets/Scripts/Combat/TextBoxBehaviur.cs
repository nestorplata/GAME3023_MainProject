using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxBehaviur : MonoBehaviour
{
    // Start is called before the first frame update
    int ChoosenAbility;
    Text Explanation;
    void Start()
    {
        Explanation = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChoosenAbility(int chosen)
    {
        ChoosenAbility = chosen;
        Debug.Log(ChoosenAbility);

    }
    public void SetText(string text)
    {
        Explanation.text = text;
    }
}
