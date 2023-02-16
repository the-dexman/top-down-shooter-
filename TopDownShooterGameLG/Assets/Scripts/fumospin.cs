using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fumospin : MonoBehaviour
{
    public int spinSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}
