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
        RaycastHit2D rayCastHit; 
        if (moveX > 0f)
        {
            eSprite.flipX = false;
            rayCastHit = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.right, BoxCollider.bounds.extents.x + extraDistance);
        }
        else
        {
            eSprite .flipX = true;
            rayCastHit = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.left, BoxCollider.bounds.extents.x + extraDistance);
        }
        moveDir = new Vector2 (moveX, moveY).normalized;
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveDir.x * moveSpeed, rigidBody.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "edge")
        {

        }
    }
}
