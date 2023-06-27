using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engineHandler : MonoBehaviour
{

    public GameObject refillFrom;
    private resourceDropoff dropzone;

    public float enginePower = 3f;
    public int maxPower = 3;

    // Start is called before the first frame update
    void Start()
    {
        dropzone = refillFrom.GetComponent<resourceDropoff>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enginePower > 0)
        {
            enginePower -= Time.deltaTime;
        }
        if (enginePower < 0) 
        {
            enginePower = 0;
        }

        if (enginePower + 1 > maxPower) 
        {
            dropzone.pickup = false;
        }
        else
        {
            dropzone.pickup = true;
        }

        if(dropzone.Value > 0) 
        {
            dropzone.Value--;
            enginePower++;
        }
    }
}
