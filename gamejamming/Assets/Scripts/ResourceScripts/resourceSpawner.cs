using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class resourceSpawner : NetworkBehaviour
{

    public enum ResourceType
    {
        AMMO,
        FUEL,
        REPAIRKIT

    }

    public static float dropHeight = 5f;
    public Vector3 spawnOffset = new Vector3(0, dropHeight, 0);
    public GameObject resource;
    public GameObject SpawnedResource;
    private bool connected = false;

    [SerializeField] private ResourceType type;

    public static string getResourceTag(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.AMMO:
                return "Ammo";
            case ResourceType.FUEL:
                return "Fuel";
            case ResourceType.REPAIRKIT:
                return "RepairKit";
            default: return null;
        }
    }


    // Start is called before the first frame update
    override
    public void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        connected = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (connected && SpawnedResource == null) spawnResource();
    }

    void spawnResource() {
        if (!IsHost) return;
        SpawnedResource = (GameObject)Instantiate(resource, spawnOffset + transform.position, Quaternion.identity);
        SpawnedResource.tag = getResourceTag(type);
        SpawnedResource.transform.GetChild(0).tag = getResourceTag(type);
        switch (type) {
            case ResourceType.AMMO:
                //red
                SpawnedResource.GetComponent<Renderer>().material.color = Color.red;
                break;
            case ResourceType.FUEL:
                //Yellow
                SpawnedResource.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case ResourceType.REPAIRKIT:
                //Green
                SpawnedResource.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
    }
}
