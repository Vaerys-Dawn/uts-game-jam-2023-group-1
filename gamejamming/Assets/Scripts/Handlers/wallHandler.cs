using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallHandler : MonoBehaviour
{

    public bool broken = false;
    public GameObject brokenWallPrefab;
    GameObject brokenWall;
    private bool hole = false;
    public Transform brokenWallPos;

    //Quaternion = brokenWallPrefab.Transformation.rotation;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hole == false && broken == true)
        {
            //spawn object
            brokenWall = (GameObject)Instantiate(brokenWallPrefab, brokenWallPos.position, brokenWallPos.rotation);
            brokenWall.transform.SetParent(brokenWallPos);
            
            hole = true;
            
        }

        if (brokenWall == null)
        {
            hole = false;
            broken = false;
        }
    }

}
