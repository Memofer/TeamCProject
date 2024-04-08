using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_sword : MonoBehaviour
{
    public int damage;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "enemy")
        {
            stats stat =other.GetComponent<stats>();
            stat.takedamage(damage*level);
        }
    }
}
