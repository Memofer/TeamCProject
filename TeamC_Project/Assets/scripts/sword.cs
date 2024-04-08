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
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hallo world");
        if (other.gameObject.tag == "enemy")
        {
            stats stat = other.GetComponent<stats>();
            stat.takedamage(damage*level);
        }
    }
}
