using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private Rigidbody2D rigidbody;
    private SpriteRenderer eSprite;
    private Animator animator;
    private bool disturbed = false;
    private bool moving;
    private float moveX = +1f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private string moveDir = "right";
    public LayerMask EdgeLayerMask;
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        eSprite = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disturbed)
        {
            moving = true;        
        }
        if (moveX == +1f)
        {
            moveDir = "right";
        }else if (moveX == -1f)
        {
            moveDir = "left";
        }
        if (WallDetected())
        {
            if(moveX == +1f)
            {
                eSprite.flipX = true;
                moveX = -1f;
            }else if(moveX == -1f)
            {
                eSprite.flipX = false;
                moveX = +1f;
            }
        }


    }
    private void FixedUpdate()
    {
        if (moving)
        {
            rigidbody.velocity = new Vector2(moveX*moveSpeed, rigidbody.velocity.y);
        }
    }
    public bool WallDetected()
    {
        float extraHeight = 1f;      
        RaycastHit2D hitWall = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.right,BoxCollider.bounds.extents.x + extraHeight, EdgeLayerMask);       
        
        return hitWall.collider != null;
    }
}
    
