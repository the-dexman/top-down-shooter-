using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float bulletLifeTimer;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTimer += Time.deltaTime;

        transform.Translate(-Vector3.right * bulletSpeed * Time.deltaTime, Space.Self);

        if (bulletLifeTimer > 5)
        {
            Destroy(gameObject);
        }
    }
}
