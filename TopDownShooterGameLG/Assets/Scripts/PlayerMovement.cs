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

    // Start is called before the first frame update
    void Start()
    {
        playerHit += PlayerHitReaction;
        boxCollider = gameObject.GetComponent<BoxCollider>();
        rigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        rigidbodyComponent.useGravity = false;
    }

    // Update is called once per frame

    void Update()
    {
        if (isDashing)
        {
            return;
        }
        playerHorizontal = Input.GetAxisRaw("Horizontal");
        playerVertical = Input.GetAxisRaw("Vertical");


        Vector3 playerMovement = new Vector3(playerHorizontal, playerVertical, 0);

        gameObject.transform.Translate(playerMovement.normalized * speed * Time.deltaTime, Space.World);


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
        rigidbodyComponent.velocity = new Vector2(playerHorizontal * dashingPower, playerVertical * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
