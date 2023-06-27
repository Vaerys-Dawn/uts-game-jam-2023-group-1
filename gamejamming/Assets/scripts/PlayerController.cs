using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private Transform carrying;
    public Vector3 carryingPosition = new Vector3(2, 0, 0);
    // Start is called before the first frame update

    public void Die()
    {
        carrying = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        switch(carrying.tag)
        {
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
        carrying.SetPositionAndRotation(transform.position + carryingPosition, transform.rotation);
    }
}
