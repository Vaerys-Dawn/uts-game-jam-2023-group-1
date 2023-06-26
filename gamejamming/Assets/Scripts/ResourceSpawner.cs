using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{


    public int spawnLayer;
    // Start is called before the first frame update
    void Start()
    {
        spawnResource();
    }

    // Update is called once per frame
    void Update()
    {
        if(true) { //object not above
            StartCoroutine(spawnWait());
        }
    }

    void spawnResource() {
        //GameObject resource = ((GameObject)Instantiate);
    }

    IEnumerator spawnWait() {
        yield return  new WaitForSeconds(5f);
        spawnResource();
    }
}
