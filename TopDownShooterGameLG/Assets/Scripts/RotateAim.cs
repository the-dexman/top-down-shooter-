using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateAim : MonoBehaviour
{
    public KeyCode downKey;
    public KeyCode upKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public Transform down;
    public Transform up;
    public Transform right;
    public Transform left;


    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(downKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        else if (Input.GetKeyDown(upKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
       
        }
    
        else if (Input.GetKeyDown(rightKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    
        else if (Input.GetKeyDown(leftKey))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    

        
    }
}
