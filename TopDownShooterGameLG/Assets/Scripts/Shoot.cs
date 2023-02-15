using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    GameObject myProjectile;
    Rigidbody rb;
    [SerializeField]
    float forceMagnitude = 300f;

    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode leftKey;

    public KeyCode shoot;

    [SerializeField]
    private float fireRate = 3.0f;
    private float timer;
    [SerializeField]
    float range;


    bool shootDelay = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {


            if (Input.GetKey(downKey) || Input.GetKey(rightKey) || Input.GetKey(leftKey) || Input.GetKey(upKey))
            {





                if (shootDelay) //to make sure you don't move and shoot on the same frame (if you turn you'll shoot the way you're facing right now first)
                {
                    shootDelay = false;
                    return;

                }
                else
                {
                    myProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject; //transform.position gör så att 

                    timer = fireRate;
                    shootDelay = true;

                }



            }
        }






    }




}
