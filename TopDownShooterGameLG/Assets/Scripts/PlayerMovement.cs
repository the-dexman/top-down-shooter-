using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public GameObject pausemenu;
    //delegates
    public delegate void PlayerHit(Transform enemyHitTransform);
    public static PlayerHit playerHit;


    ControllerActions controllerActions;
    Vector2 controllerMovement;
    public int time;
    float minAxis;

    private void Awake()
    {
        controllerActions = new ControllerActions();

        controllerActions.gamingActionMap.movement.performed += context => controllerMovement = context.ReadValue<Vector2>(); // movement is set to the thumbstick value
        controllerActions.gamingActionMap.movement.canceled += context => controllerMovement = Vector2.zero;
    }

    private void OnEnable()
    {
        controllerActions.gamingActionMap.Enable();
    }
    private void OnDisable()
    {
        controllerActions.gamingActionMap.Disable();
    }

    void Start()
    {
        minAxis = joystickvars.minimumAxis;
        Instantiate(pausemenu, transform.position, Quaternion.identity);
        rigidbodyComponent.useGravity = false;


        //add functions to delegates
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

        //!true = false
        if (!PauseScript.pauseEnabled)
        {
            //yandere dev code my beloved
            if (controllerMovement.x <= 0.5f && controllerMovement.x >= 0)
            {
                controllerMovement.x = 0;
            }
            else if (controllerMovement.x >= -0.5f && controllerMovement.x <= 0)
            {
                controllerMovement.x = 0;
            }
            else if (controllerMovement.x > 0.5f)
            {
                controllerMovement.x = 1;
            }
            else if (controllerMovement.x < -0.5f)
            {
                controllerMovement.x = -1;
            }

            if (controllerMovement.y <= 0.5f && controllerMovement.y >= 0)
            {
                controllerMovement.y = 0;
            }
            else if (controllerMovement.y >= -0.5f && controllerMovement.y <= 0)
            {
                controllerMovement.y = 0;
            }
            else if (controllerMovement.y > 0.5f)
            {
                controllerMovement.y = 1;
            }
            else if (controllerMovement.y < -0.5f)
            {
                controllerMovement.y = -1;
            }

            upAxis = controllerMovement.y;
            rightAxis = controllerMovement.x;

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

            if (HealthManager.playerHealth <= 0)
            {
                Debug.Log("player is dead");
                animator.SetInteger("AnimationID", -1);
                animator.Play("PlayerDeath");
                spriteRenderer.color = Color.white;

                transform.GetChild(0).gameObject.SetActive(false);

                enabled = false;
            }

            if (Input.GetKey(dashArcade) || Input.GetKeyDown(dashKeyboard) && canDash)
            {
                gameObject.GetComponent<PlayAudio>().PlaySound(2);
                StartCoroutine(Dash());
            }

        }
    }



    void PlayerHitReaction(Transform enemyHitTransform)
    {
        Vector3 directionToEnemy = enemyHitTransform.position - gameObject.transform.position;
        directionToEnemy.z = 0;

        gameObject.GetComponent<Rigidbody>().AddForce(directionToEnemy.normalized * -1 * bounceSpeed, ForceMode.Impulse);

    }

    IEnumerator Dash()
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



    IEnumerator InvincibilityFrames(float time, Color color)
    {
        isInvincible = true;
        spriteRenderer.color = color;
        Debug.Log("Invincible");
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

                Debug.Log("player hit");

                gameObject.GetComponent<PlayAudio>().PlaySound(1);
                StartCoroutine(InvincibilityFrames(invincibilityTime, hurtColor));

                if (collision.gameObject.tag == "Bullet")
                {
                    Destroy(collision.gameObject);
                }


                isColliding = true;

                playerHit(collision.gameObject.transform);
            }


        }


    }
}
