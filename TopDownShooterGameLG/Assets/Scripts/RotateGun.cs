using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode leftKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetKey(leftKey))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        else if (Input.GetKey(rightKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if (Input.GetKey(downKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
