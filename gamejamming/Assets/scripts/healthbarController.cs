using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarController : MonoBehaviour
{
    public HealthScript healthScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale.Set(healthScript.energy / 100, 1, 1);   
    }
}
