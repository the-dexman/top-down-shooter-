using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //dash variables
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public bool canDash = true;
    public bool isDashing = false;
    public KeyCode dashArcade;
    public KeyCode dashKeyboard;


    //invincibility variables
    public float invincibilityTime;
    bool isInvincible;
    public Color dashColor;
    public Color hurtColor;

    //damage variables
    public Rigidbody rigidbodyComponent;
    public float bounceSpeed;
    bool isColliding = false;
    

    //object references
    BoxCollider boxCollider;
    Animator animator;
    SpriteRenderer spriteRenderer;

    //movement variables
    public float speed = 2f;
    float upAxis;
    float rightAxis;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

    //delegates
    public delegate void PlayerHit(Transform enemyHitTransform);
    public static PlayerHit playerHit;
    

    // Start is called before the first frame update oui oui tr�s bien
    void Start()
    {
        rigidbodyComponent.useGravity = false;
        

        //add functions to delegates
        HealthManager.playerDeath += OnDeath;
        playerHit += PlayerHitReaction;

        //initializing objects
        animator = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        rigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {
        isColliding = false;

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
            animator.SetInteger("AnimationID", 1);
        }
        else if (rightAxis == 1 && upAxis == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("AnimationID", 2);
        }
        else if (rightAxis == 1 && upAxis == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("AnimationID", 3);
        }
        else if (rightAxis == -1 && upAxis == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("AnimationID", 1);
        }
        else if (rightAxis == -1 && upAxis == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("AnimationID", 2);
        }
        else if (rightAxis == -1 && upAxis == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("AnimationID", 3);
        }
        else if (rightAxis == 0 && upAxis == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetInteger("AnimationID", 4);
        }
        else if (rightAxis == 0 && upAxis == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("AnimationID", 5);
        }
        else
        {  
            animator.SetInteger("AnimationID", 0);
        }
		

        if (Input.GetKey(dashArcade) || Input.GetKeyDown(dashKeyboard) && canDash)
        {
            gameObject.GetComponent<PlayAudio>().PlaySound(2);
            StartCoroutine(Dash());
        }

    }

    void OnDeath()
    {
        animator.SetInteger("AnimationID", -1);
        animator.Play("PlayerDeath");
        spriteRenderer.color = Color.white;
        
        gameObject.GetComponent<PlayerMovement>().enabled = false;
    }

    void PlayerHitReaction(Transform enemyHitTransform)
    {
        Vector3 directionToEnemy = enemyHitTransform.position - gameObject.transform.position;
        directionToEnemy.z = 0;

        gameObject.GetComponent<Rigidbody>().AddForce(directionToEnemy.normalized * -1 * bounceSpeed, ForceMode.Impulse);
        
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigidbodyComponent.velocity = new Vector2(rightAxis, upAxis).normalized * dashingPower;
        animator.SetInteger("AnimationID", 6);
        StartCoroutine(InvincibilityFrames(dashingTime, dashColor));
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }



    private IEnumerator InvincibilityFrames(float time, Color color)
    {
        isInvincible = true;
        spriteRenderer.color = color;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
        isInvincible = false;
            
    }

    private void OnTriggerStay(Collider collision)
    {

        

        if (isInvincible == false && isColliding == false)
        {
            if (collision.gameObject.layer == 6)
            {
                playerHit(collision.gameObject.transform);

                gameObject.GetComponent<PlayAudio>().PlaySound(1);
                StartCoroutine(InvincibilityFrames(invincibilityTime, hurtColor));

                if (collision.gameObject.tag == "Bullet")
                {
                    Destroy(collision.gameObject);
                }

                isColliding = true;
            }

            
        }
        

    }
}
