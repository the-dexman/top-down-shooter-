using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapearAfterTime : MonoBehaviour
{
    public float desiredTime;
    float count;

    void Update()
    {
        if (count > desiredTime)
        {
            gameObject.SetActive(false);
        }
        else
        {
            count += Time.deltaTime;
        }
    }
}
