using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2f;
    public float bounceSpeed;
    BoxCollider boxCollider;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public delegate void PlayerHit(Transform enemyHitTransform);
    public static PlayerHit playerHit;
    Animator animator;

    int rotate;

    // Start is called before the first frame update
    void Start()
    {
        playerHit += PlayerHitReaction;

        animator = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame

    void Update()
    {
        float upAxis = Input.GetAxisRaw("Vertical");
        float rightAxis = Input.GetAxisRaw("Horizontal");
        


        if (rightAxis == 1 && upAxis == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("WalkID", 1);
        }
        else if (rightAxis == 1 && upAxis == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("WalkID", 2);
        }
        else if (rightAxis == -1 && upAxis == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("WalkID", 1);
        }
        else if (rightAxis == -1 && upAxis == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("WalkID", 2);
        }
        else
        {  
            animator.SetInteger("WalkID", 0);
        }


        Vector3 playerMovement = new Vector3(rightAxis, upAxis, 0);

        gameObject.transform.Translate(playerMovement.normalized * speed * Time.deltaTime, Space.World);

        
        


    }

    void PlayerHitReaction(Transform enemyHitTransform)
    {
        Vector3 directionToEnemy = enemyHitTransform.position - gameObject.transform.position;

        gameObject.GetComponent<Rigidbody>().AddForce(directionToEnemy * -1 * bounceSpeed, ForceMode.Impulse);
        
    }
}
