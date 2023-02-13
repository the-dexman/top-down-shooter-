using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowingScript : MonoBehaviour
{

    public Transform followingTarget;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followingDirection = followingTarget.position - transform.position;

        transform.Translate(new Vector3(followingDirection.x, followingDirection.y, -10) * followSpeed * Time.deltaTime);
        
    }
}
