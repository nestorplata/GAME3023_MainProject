using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using System.IO;

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
    public void EraseSave ()
    {
       new StreamWriter("Assets\\Saved\\Position.txt").Close();
    }

    public void SaveGame(GameObject player)
    {
        using (StreamWriter writer = new StreamWriter("Assets\\Saved\\Position.txt"))
        {
            Vector3 Restant = new Vector3();

            Restant.x = (player.transform.position.x - 0.08f) % 0.16f;
            Restant.y = (player.transform.position.y - 0.08f) % 0.16f;

            if(Mathf.Abs(Restant.x) > 0.159f)
            {
                Restant.x = 0;
            }
            if (Mathf.Abs(Restant.y) > 0.159f)
            {
                Restant.y = 0;
            }

            Debug.Log(player.transform.position);
            Debug.Log(Restant);
            writer.WriteLine(player.transform.position-Restant);
        }

    }


}
