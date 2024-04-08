using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_character : MonoBehaviour
{
    private Rigidbody2D rigbody2D;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rigbody2D.GetComponent<Rigidbody2D>();
        boxCollider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void fixedupdate()
    {
        
    }
}
