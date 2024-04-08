using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public int maxhealth;
    public int maxmana;
    public int current_health;
    public int current_mana;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takedamage(int damage){
        Debug.Log("bruh");
        current_health= current_health - damage;
    }
}
