using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fumospin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float youAreRacist = transform.rotation.y;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, youAreRacist + 1, transform.rotation.z)); 
    }
}
