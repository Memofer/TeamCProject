using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sword : MonoBehaviour
{
    [SerializeField]private string et;
    public int damage;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == et)
        {
            stats stat = other.GetComponent<stats>();
            stat.takedamage(damage*level);
        }
    }
}
