using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public bool canDash = true;
    public bool isDashing = false;
    public KeyCode dash;
    float playerHorizontal;
    float playerVertical;
    public Rigidbody rigidbodyComponent;

    public float speed = 2f;
    public float bounceSpeed;
    BoxCollider boxCollider;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public delegate void PlayerHit(Transform enemyHitTransform);
    public static PlayerHit playerHit;
    float upAxis;
    float rightAxis;
    Animator animator;

    int rotate;

    // Start is called before the first frame update oui oui trés bien
    void Start()
    {
        playerHit += PlayerHitReaction;

        animator = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        rigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        rigidbodyComponent.useGravity = false;
    }

    // Update is called once per frame

    void Update()
    {

        upAxis = Input.GetAxisRaw("Vertical");
        rightAxis = Input.GetAxisRaw("Horizontal");


        if (isDashing)
        {
            return;
        }
		
		
		 Vector3 playerMovement = new Vector3(rightAxis, upAxis, 0);

        gameObject.transform.Translate(playerMovement.normalized * speed * Time.deltaTime, Space.World);

        //Walk animations
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
        else if (rightAxis == 1 && upAxis == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("WalkID", 3);
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
        else if (rightAxis == -1 && upAxis == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("WalkID", 3);
        }
        else if (rightAxis == 0 && upAxis == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("WalkID", 4);
        }
        else if (rightAxis == 0 && upAxis == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("WalkID", 5);
        }
        else
        {  
            animator.SetInteger("WalkID", 0);
        }
		

        if (Input.GetKey(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    void PlayerHitReaction(Transform enemyHitTransform)
    {
        Vector3 directionToEnemy = enemyHitTransform.position - gameObject.transform.position;

        gameObject.GetComponent<Rigidbody>().AddForce(directionToEnemy * -1 * bounceSpeed, ForceMode.Impulse);
        
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigidbodyComponent.velocity = new Vector2(rightAxis * dashingPower, upAxis * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
