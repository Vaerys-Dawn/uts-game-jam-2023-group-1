using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public Transform carrying;
    public Vector3 carryingPosition = new Vector3(2, 0, 0);
    // Start is called before the first frame update

    public void Die()
    {
        carrying = null;
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
                    carrying = other.transform;
                break;
            case "Ammo":
            case "Fuel":
            case "RepairKit":
                carrying = other.transform;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + carryingPosition, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying == null) { 
            return;
        }
        carrying.transform.position = transform.position + carryingPosition;
    }
}
