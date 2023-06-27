using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScripty : MonoBehaviour
{
    

    public int health;
    public int damageValue;
    float nextAttack;

    ShipScript shipScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAttack <= 0)
        {
            nextAttack = Random.Range(5f, 15f);
            //attack
            //shipScript.hit = true;
        }
        else 
        {
            nextAttack -= Time.deltaTime;
        }
       
    }

    public void damage()
    {
        health = health - damageValue;
    }
}
