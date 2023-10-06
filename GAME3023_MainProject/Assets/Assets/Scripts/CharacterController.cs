using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    public float TileSize;

    public LayerMask SolidObjectsLayer;

    private bool isMoving;
    private bool isYDominant;

    private Vector2 input;
    
    private Animator animator;
    private BoxCollider2D Collider;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
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
                Debug.Log(input);
                var targetPos = transform.position;
                targetPos.x += input.x*TileSize;
                targetPos.y += input.y*TileSize;

                if(IsWalkable(targetPos))
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
        if(Physics2D.OverlapBox(targetPos, new Vector2(0.08f, 0.08f), SolidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }
}
