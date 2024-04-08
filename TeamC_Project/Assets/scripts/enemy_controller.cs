using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    private SpriteRenderer eSprite;
    private BoxCollider2D BoxCollider;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private float moveX;
    private Vector2 moveDir;
    private float moveY = +1f;
    [SerializeField] private int moveSpeed = 10;
    [SerializeField] private LayerMask Layermask;
    [SerializeField] private float extraDistance = 1f;
    private bool interrupted;
    [SerializeField]private GameObject sword;
    
    void Start()
    {
        eSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        moveX = +1f;
    }

    // Update is called once per frame
    void Update()
    {
        interrupted = false;
        RaycastHit2D rayCastHit;
        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);
        if (moveX > 0f)
        {
            eSprite.flipX = false;
            rayCastHit = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.right, BoxCollider.bounds.extents.x + extraDistance,Layermask);
            if (rayCastHit)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Attacking", true);
                interrupted = true;
            }
        }
        else
        {
            eSprite .flipX = true;
            rayCastHit = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.left, BoxCollider.bounds.extents.x + extraDistance,Layermask);
            if (rayCastHit)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Attacking", true);
                interrupted = true;
            }
        }

        moveDir = new Vector2(moveX, moveY).normalized;
    }
    private void FixedUpdate()
    {
        if (!interrupted) 
        { 
            rigidBody.velocity = new Vector2(moveDir.x * moveSpeed, rigidBody.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "edge")
        {
            if(moveX > 0f)
            {
                moveX = -1f;
            }else if(moveX <0)
            {
                moveX = +1f;
            }
            }
    }
    public void EnableSword()
    {
        sword.SetActive(true);
    }
}
