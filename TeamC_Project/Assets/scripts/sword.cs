using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sword : MonoBehaviour
{
    public int damage;
    public int level;
    private PolygonCollider2D boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            stats stat =other.GetComponent<stats>();
            stat.takedamage(damage*level);
        }
    }
}
