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
    Animator animator;
    EnemyMovement movementScript;
    float tempMovementSpeed;


    public float bulletSpread;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = gameObject.GetComponent<EnemyMovement>();
        tempMovementSpeed = movementScript.movementSpeed;
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
                bullet.transform.Rotate(0, 90, Random.Range(-bulletSpread, bulletSpread));
                animator.Play("SniperZombieShoot");
                movementScript.movementSpeed = 0;
            }
            

            shootTimer = 0;
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("stopMoving"))
        {
            movementScript.movementSpeed = tempMovementSpeed;
        }

    }
}
