using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private EnemyDrop getItem;

    public GameObject playerObject;
    public float movementSpeed;
    public int enemyType;
    public float rangedEnemyDistance;
    internal Animator animator;
    internal float enemyHealth;
    public float maxHealth;
    public Color deathColor;
    public Color hurtColor;
    public float hurtTime;
    public float ambientTimerLengthMin;
    public float ambientTimerLengthMax;
    float ambientTimerLength;
    float ambientTimer;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    Vector3 playerDirection;

    public AudioClip[] deathSounds;
    public AudioClip[] ambientSounds;
    public AudioClip[] hurtSounds;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyHealth = maxHealth;

        audioSource = gameObject.GetComponent<AudioSource>();

        getItem = GetComponent<EnemyDrop>();

        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), playerObject.GetComponent<CapsuleCollider>(), true);
        ambientTimerLength = Random.Range(ambientTimerLengthMin, ambientTimerLengthMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthManager.playerHealth <= 0)
        {
            if (gameObject.GetComponent<EnemyShootScript>() != null)
            {
                Destroy(gameObject.GetComponent<EnemyShootScript>());

            }

            Destroy(this);
        }


        transform.position = new Vector3(transform.position.x, transform.position.y, playerObject.transform.position.z);

        ambientTimer += Time.deltaTime;
        if (ambientTimer >= ambientTimerLength)
        {
            PlaySound(ambientSounds);
            ambientTimer = 0;
            ambientTimerLength = Random.Range(ambientTimerLengthMin, ambientTimerLengthMax);
        }

        if (enemyHealth <= 0)
        {
            if (getItem != null)
            {
               
                getItem.MobDrops();
                
            }
            PlaySound(deathSounds);

            if (gameObject.GetComponent<EnemyShootScript>() != null)
            {
                Destroy(gameObject.GetComponent<EnemyShootScript>());
                
            }
            gameObject.GetComponent<SpriteRenderer>().color = deathColor;
            Destroy(gameObject.GetComponent<BoxCollider>());
            animator.SetInteger("animationID", -1);
            animator.Play("EnemyDeath");
            Destroy(this);
        }

        playerDirection = playerObject.transform.position - gameObject.transform.position;

        if (playerDirection.x > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (playerDirection.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        


        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("stopMoving") == false)
        {
            if (enemyType == 0)
            {
                BasicMeleeEnemy();
            }
            if (enemyType == 1)
            {
                BasicRangedEnemy();
            }
        }

        

    }

    void BasicMeleeEnemy()
    {
        gameObject.transform.Translate(playerDirection.normalized * movementSpeed * Time.deltaTime, Space.World);
    }

    void BasicRangedEnemy()
    {
        if (playerDirection.magnitude > rangedEnemyDistance + 1)
        {
            gameObject.transform.Translate(playerDirection.normalized * movementSpeed * Time.deltaTime, Space.World);
        }
        if (playerDirection.magnitude < rangedEnemyDistance - 1)
        {
            gameObject.transform.Translate(playerDirection.normalized * -1 * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    internal void OnHurt()
    {
        StartCoroutine(FlashRed());
        PlaySound(hurtSounds);
    }

    internal IEnumerator FlashRed()
    {
        spriteRenderer.color = hurtColor;

        yield return new WaitForSeconds(hurtTime);
        spriteRenderer.color = Color.white;
    }

    internal void PlaySound(AudioClip[] soundArray)
    {
        audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        audioSource.clip = soundArray[Random.Range(0, soundArray.Length)];
        audioSource.Play();
    }

}
