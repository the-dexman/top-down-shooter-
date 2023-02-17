using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateAim : MonoBehaviour
{
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode leftKey;

    


    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        HealthManager.playerDeath += RemoveGun;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        if (Input.GetKey(downKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetKey(leftKey))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        if (Input.GetKey(upKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKey(leftKey) && Input.GetKey(upKey))
        {

            transform.rotation = Quaternion.Euler(0, 180, 45);


        }
        if (Input.GetKey(rightKey) && Input.GetKey(upKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if (Input.GetKey(rightKey) && Input.GetKey(downKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (Input.GetKey(leftKey) && Input.GetKey(downKey))
        {
            transform.rotation = Quaternion.Euler(0, 180, -45);
        }







    }
    void RemoveGun()
    {
        gameObject.SetActive(false);
    }
}
