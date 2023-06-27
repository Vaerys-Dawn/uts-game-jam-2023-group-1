using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public Transform carrying;
    public Transform carryingPosition;
    private HealthScript heldScript;
    // Start is called before the first frame update

    public void Die()
    {
        carrying = null;
        heldScript = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        print("bonk");
        switch(other.tag)
        {
            case "Player":
                HealthScript healthScript = other.transform.GetComponent<HealthScript>();
                if (healthScript != null && !healthScript.alive)
                {
                    carrying = other.transform;
                    heldScript = healthScript;
                }
     
                break;
            case "Ammo":
            case "Fuel":
            case "RepairKit":
                carrying = other.transform;
                heldScript = null;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(carryingPosition.position, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying == null) { 
            return;
        }
        if(heldScript != null && heldScript.energy != 0)
        {
            carrying = null;
            heldScript = null;
        } 
        carrying.transform.position = carryingPosition.position;
    }
}
