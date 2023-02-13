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

    public GameObject projectile;
    GameObject myProjectile;
    Rigidbody rb;

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
            myProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            GameObject GO = Instantiate();

            GO.transform.parent = ParentGameObject;
        }
        else if (Input.GetKeyDown(upKey))
        {
            
        }
        else if (Input.GetKeyDown(rightKey))
        {
            
        }
        else if (Input.GetKeyDown(leftKey))
        {
            
        }
    }
}
