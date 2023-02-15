using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fumospin : MonoBehaviour
{
    public int spinSpeed;

    // Update is called once per frame
    void Update()
    {
        float youAreRacist = transform.rotation.y;
        gameObject.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}
