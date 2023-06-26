using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform carrying;
    public Transform carryingPosition;
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

    // Update is called once per frame
    void Update()
    {
        carrying.SetPositionAndRotation(carryingPosition.position, carryingPosition.rotation);
    }
}
