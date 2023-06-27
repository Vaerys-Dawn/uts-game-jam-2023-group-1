using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{


    public int health = 100; 
    public bool hit = false;
    public engineHandler[] engines;
    public doorHandler[] doors;
    public wallHandler[] walls;
    private int engineLevel = 0;
    private int damageType;
    public int dmgRange = 3;
    private int hitChoice;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            //damage
            Debug.Log("Ship hit");
            health -= 1 * (15 - totalPower())  ;//subtract engine power
            hit = false;
            engineLevel = 0;
            for(int i = 0; i < engines.Length; i++)
            {
                engines[i].enginePower -= 1;
            }

            damageType = Random.Range(1, dmgRange);
            

            switch (damageType){
                case 1:
                    //wall break
                    hitChoice = Random.Range(1, walls.Length);
                    walls[hitChoice].broken = true;
                    break;
                case 2:
                    //door jam
                    hitChoice = Random.Range(1, doors.Length);
                    doors[hitChoice].jam = true;
                    break;
                default:
                    //nothing
                    break;
            }



        }

        if (health <= 0)
        {
            //game over
        }
    }

    int totalPower()
    {
        for (int i = 0; i < engines.Length; i++)
        {
            engineLevel += (int)engines[i].enginePower;
        }

        return engineLevel;
    }

}
