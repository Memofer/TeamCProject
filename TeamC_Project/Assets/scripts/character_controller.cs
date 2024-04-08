using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class main_character : MonoBehaviour
{
    public GameObject sword;
    private bool jumping;
    [SerializeField]float extraheight = +1f;
    [SerializeField]private LayerMask platformlayermask;
    [SerializeField]private float speed;
    [SerializeField]private float jumpforce;
    private Rigidbody2D rigbody;
    private BoxCollider2D boxCollider;
    private float moveX;
    private float moveY;
    private Animator animator;
    private SpriteRenderer pSprite;
    private Vector2 movedir;
    // Start is called before the first frame update
    void Start()
    {
        pSprite = GetComponent<SpriteRenderer>();
        rigbody=GetComponent<Rigidbody2D>();
        boxCollider=GetComponent<BoxCollider2D>();
        animator=GetComponent<Animator>();
    }
    void Update()
    {
     animator.SetBool("running", false);
     moveX = 0f;
     moveY = 0f;
     if (Input.GetKeyDown(KeyCode.W))
     {
        animator.SetBool("on_air",true);
        jumping = true;
        moveY=+1f;
     }
     if (Input.GetKey(KeyCode.D))
     {
        pSprite.flipX = false;
        moveX=+1f;
        animator.SetBool("running", true);
        sword.transform.eulerAngles = new Vector3(0f, 0f, 0f);
     }
     if (Input.GetKey(KeyCode.A))
     {
        animator.SetBool("running", true);
        moveX=-1f;
        pSprite.flipX=true;
        sword.transform.eulerAngles = new Vector3(0, 180f, 0f);
     }
     if (Input.GetKeyDown(KeyCode.Mouse0))
     {
        animator.SetBool("attacking",true);
        sword.SetActive(true);
     }
     movedir = new Vector2(moveX, moveY).normalized;
     animator.SetFloat("moveX", Mathf.Abs(moveX));
     animator.SetFloat("moveY",rigbody.velocity.y);
    }
    private void FixedUpdate() {
        if (jumping && isgrounde())
        {
            jumping=false;
            rigbody.velocity = new Vector2(rigbody.velocity.x, jumpforce);
        }
        rigbody.velocity = new Vector2(moveX*speed, rigbody.velocity.y);
    }
    private bool isgrounde(){
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down,boxCollider.bounds.extents.x+extraheight,platformlayermask);
        return raycastHit.collider !=null;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "platform")
        {
            animator.SetBool("on_air", false);
        }
    }
    private void onsword(){
        sword.SetActive(true);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("attacking", true);
        }
        else{
            animator.SetBool("attacking",false);
        }
    }
}
