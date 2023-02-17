using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float bulletLifeTimer;
    public float bulletLifeTimerLength;
    public float bulletSpeed;
    public float bulletDamage;
    public int directionMultiplier;
    public bool explodeOnDeath;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTimer += Time.deltaTime;

        transform.Translate(-Vector3.right * directionMultiplier * bulletSpeed * Time.deltaTime, Space.Self);

        if (bulletLifeTimer > bulletLifeTimerLength)
        {
            if (explodeOnDeath)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.layer == 3)
        {
            if (other.gameObject.GetComponent<EnemyMovement>() != null)
            {
                other.gameObject.GetComponent<EnemyMovement>().enemyHealth -= bulletDamage;
                other.gameObject.GetComponent<EnemyMovement>().OnHurt();
            }
            
            Destroy(this.gameObject);
        }
    }
}
