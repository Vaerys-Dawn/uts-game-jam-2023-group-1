using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallHandler : MonoBehaviour
{

    public bool broken = false;
    public GameObject brokenWallPrefab;
    GameObject brokenWall;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(broken)
        {
            //spawn object
            brokenWall = (GameObject)Instantiate(brokenWallPrefab, transform.position, Quaternion.identity);
        }

        if (brokenWall == null)
        {
            broken = false;
        }
    }

}
