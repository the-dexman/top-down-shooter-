using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    GameObject myProjectile;
    Rigidbody rb;
    float forceMagnitude = 40;

    public KeyCode downKey;
    public KeyCode upKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("space"))
        {
            myProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject; //transform.position gör så att 

            rb = myProjectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.right * forceMagnitude, ForceMode.Impulse); //ForceMode.Impulse lägger till en direkt kraft beroende på massan av objektet

            Destroy(myProjectile, 4f);
        }
    }
}
