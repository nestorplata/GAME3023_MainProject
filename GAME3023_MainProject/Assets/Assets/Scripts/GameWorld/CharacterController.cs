using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System.Globalization;
using System;

public class CharacterController : MonoBehaviour
{
    [SerializeField] SceneToogler SceneChanger;

    public float moveSpeed;
    public float TileSize;

    public LayerMask SolidObjectsLayer;
    public LayerMask EncounterLayer;


    private bool isMoving;
    private bool isYDominant;

    private Vector2 input;
    
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        using (StreamReader Reader = new StreamReader("Assets\\Assets\\Saved\\Position.txt"))
        {
            Debug.Log(Reader.Peek());
            if (Reader.Peek() >= 0)
            {
                string[] PlayerPosition = Reader.ReadLine().Split(',', '(', ')');
                Vector2 Position = Vector2.zero;
                Debug.Log(PlayerPosition[1]+"&"+ PlayerPosition[2]);

                Position.x= (float)Convert.ToDouble(PlayerPosition[1]);
                Position.y= (float)Convert.ToDouble(PlayerPosition[2]);


                transform.position = Position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            if (input.x != 0 && !isYDominant)
            {
                    input.y = 0;
            }

            if (input.y != 0) 
            {
                input.x = 0;
                isYDominant = true;
            }
            else
            {
                isYDominant = false;
            }

            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);



            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x*TileSize;
                targetPos.y += input.y*TileSize;

                if (IsEncounter(targetPos))
                {
                    SceneChanger.SaveGame(gameObject);
                    SceneChanger.MoveToScene(2);
                }

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        

        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapBox(targetPos, new Vector2(0.08f, 0.08f), 0, SolidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    private bool IsEncounter(Vector3 targetPos)
    {
        if (Physics2D.OverlapBox(targetPos, new Vector2(0.08f, 0.08f), 0, EncounterLayer) != null)
        {
            return true;
        }
        return false;

    }
}
