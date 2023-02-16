using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiSoftLock : MonoBehaviour
{
    public bool xValue;
    public bool yValue;
    public float changeValue;
    void OnTriggerStay(Collider other)
    {
        if (xValue)
        {
            Vector3 posChange = new Vector3(changeValue, 0, 0);
            other.transform.position += posChange;
        }
        else if (yValue)
        {
            Vector3 posChange = new Vector3(0, changeValue, 0);
            other.transform.position += posChange;
        }
        
    }
}
