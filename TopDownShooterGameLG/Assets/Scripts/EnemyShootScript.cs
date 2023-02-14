using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{

    public Transform target;
    float shootTimer;
    public float shootTimerLength;
    public float bulletAmount;
    public GameObject bulletObject;
    public Transform shootPoint;


    public float bulletSpread;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer > shootTimerLength)
        {
            for (int i = 0;i<bulletAmount;i++)
            {
                GameObject bullet = Instantiate(bulletObject, shootPoint.position, shootPoint.rotation);
                bullet.transform.LookAt(target);
                bullet.transform.Rotate(0, 0, Random.Range(-bulletSpread, bulletSpread));
            }
            

            shootTimer = 0;
        }
        

    }
}
