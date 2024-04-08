using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class main_character : MonoBehaviour
{
    private string lookdir;
    [SerializeField]private float jumpforce;
    [SerializeField]private float movespeed;
    private Rigidbody2D rigbody;
    private BoxCollider2D boxCollider;
    private Vector2 movedir;
    private Animator animator;
    private SpriteRenderer pSprite;

    private float moveX;
    private float moveY;
    private bool jumping;
    void Start()
    {
        pSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveX = 0;
        moveY = 0;
        animator.SetBool("running", false);
        if (Input.GetKey(KeyCode.D))
        {
            lookdir = "left";
            pSprite.flipX = false;
            animator.SetBool("running", true);
            moveX = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            lookdir = "right";
            pSprite.flipX = true;
            animator.SetBool("running", true);
            moveX = -1f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumping=true;
            animator.SetBool("on_air", true);
            moveY = +1f;
        }
        movedir = new Vector2(moveX,moveY).normalized;
        animator.SetFloat("moveX", Mathf.Abs(moveX));
        animator.SetFloat("moveY",rigbody.velocity.y);
    }
    private void FixedUpdate()
    {
        if (jumping)
        {
            rigbody.velocity = new Vector2(rigbody.velocity.x, jumpforce);
            jumping=false;
        }
        rigbody.velocity =new Vector2(movedir.x*movespeed, rigbody.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "platform")
        {
            animator.SetBool("on_air", false);  
        }
    }
}
