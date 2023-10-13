using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class UIButtonsCombat : MonoBehaviour
{

    public bool IsPressed;

    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {

        coroutine = ReturnSize(1.0f);
    }

    public void OnMousePressed()
    {
        if (!IsPressed)
        {
            transform.localScale = Vector3.one * 3 / 4;
            IsPressed = true;
            StartCoroutine(ReturnSize(1.0f));
        }

    }

    // Update is called once per frame
    void Update()
    {
 

    }

    IEnumerator ReturnSize(float waitTime)
    { 
        yield return new WaitForSeconds(waitTime);
        transform.localScale = Vector3.one;
        IsPressed = false;
        
    }
}
