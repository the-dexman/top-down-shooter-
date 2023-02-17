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
    public AudioClip[] shootSounds;


    public float bulletSpread;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
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
                animator.Play("EnemyShoot");
                animator.SetInteger("animationID", -1);
            }

            gameObject.GetComponent<EnemyMovement>().PlaySound(shootSounds);
            

            shootTimer = 0;
        }

    }
}
