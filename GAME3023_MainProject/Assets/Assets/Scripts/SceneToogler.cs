using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class SceneToogler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveToScene(int sceneID)
    {
            SceneManager.LoadScene(sceneID);
        transform.localScale = Vector3.one/2;
    }
    public void Quit()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
        transform.localScale = Vector3.one / 2;

    }


}
