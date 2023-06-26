using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillStock : MonoBehaviour
{

    public GameObject refillFrom;
    private resourceDropoff dropzone;
    public int internalCount;
    public int maxStorage = 3;

    // Start is called before the first frame update
    void Start()
    {
        dropzone = refillFrom.GetComponent<resourceDropoff>();
    }

    // Update is called once per frame
    void Update()
    {

        if (internalCount >= maxStorage) {
            dropzone.Value = -1;
        }
        if(dropzone.Value > 0) {
            dropzone.Value--;
            internalCount++;
        }
    }
}
