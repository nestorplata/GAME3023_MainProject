using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class SceneToogler : MonoBehaviour
{
    private Button button;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("LevelChanger").GetComponent<Animator>();
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { Deactivate(); });
    }

    public void Deactivate()
    {
        StartCoroutine(ReturnSize(1.0f));
    }

    public void MoveToScene(int sceneID)
    {
        StartCoroutine(WaitForSceneChange(1.0f, sceneID));

    }
    public void Quit()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();

    }
    public void EraseSave ()
    {
       new StreamWriter("Assets\\Assets\\Saved\\Position.txt").Close();
    }
    public void CheckForSave(int ID)
    {
        StreamReader Reader = new StreamReader("Assets\\Assets\\Saved\\Position.txt");
        if (Reader.Peek() >= 0)
        {
            MoveToScene(ID);
        }
        else
        {
            Debug.Log("Unable to Open File");
        }
        Reader.Close();
    }

    public void SaveGame(GameObject player)
    {
        using (StreamWriter writer = new StreamWriter("Assets\\Assets\\Saved\\Position.txt"))
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

            writer.WriteLine(player.transform.position-Restant);
        }
           

    }

    IEnumerator ReturnSize(float time)
    {
        transform.localScale = transform.localScale*3/2;
        button.interactable = false;
        yield return new WaitForSeconds(time);
        transform.localScale = transform.localScale*2/3;
        button.interactable = true;
    }
    IEnumerator WaitForSceneChange(float time, int sceneID)
    {
        animator.SetTrigger("OnSceneChange");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneID);

    }



}
