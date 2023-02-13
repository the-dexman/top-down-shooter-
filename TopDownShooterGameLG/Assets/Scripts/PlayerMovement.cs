using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rigidbodyComponent;
    BoxCollider boxCollider;
    public KeyCode leftKey;
    public KeyCode rightKey;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame

    void Update()
    {
        //Walking
        if (Input.GetKey(rightKey))
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime, Space.World);
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);

        }

        if (Input.GetKey(leftKey))
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime, Space.World);
            gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        
        
    }
}
