using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    GameObject myProjectile;
    Rigidbody rb;
    [SerializeField]
    float forceMagnitude = 300f;

    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode leftKey;

    public KeyCode shoot;

    public AudioClip shootSound;
    AudioSource audioSource;

    [SerializeField]
    private float fireRate = 3.0f;
    private float timer;
    [SerializeField]
    float range;


    bool shootDelay = true;

    ControllerActions controllerActions;
    Vector2 shootDirection;
    public int time;
    float minAxis;
    private void Awake()
    {
        controllerActions = new ControllerActions();

        controllerActions.gamingActionMap.shootInDirection.performed += context => shootDirection = context.ReadValue<Vector2>(); // movement is set to the thumbstick value
        controllerActions.gamingActionMap.shootInDirection.canceled += context => shootDirection = Vector2.zero;
    }

    private void OnEnable()
    {
        controllerActions.gamingActionMap.Enable();
    }
    private void OnDisable()
    {
        controllerActions.gamingActionMap.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
        }
        audioSource = gameObject.GetComponent<AudioSource>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //yandere dev code my beloved
        if (shootDirection.x <= 0.55f && shootDirection.x >= 0)
        {
            shootDirection.x = 0;
        }
        else if (shootDirection.x >= -0.55f && shootDirection.x <= 0)
        {
            shootDirection.x = 0;
        }
        else if (shootDirection.x > 0.55f)
        {
            shootDirection.x = 1;
        }
        else if (shootDirection.x < -0.55f)
        {
            shootDirection.x = -1;
        }

        if (shootDirection.y <= 0.55f && shootDirection.y >= 0)
        {
            shootDirection.y = 0;
        }
        else if (shootDirection.y >= -0.55f && shootDirection.y <= 0)
        {
            shootDirection.y = 0;
        }
        else if (shootDirection.y > 0.55f)
        {
            shootDirection.y = 1;
        }
        else if (shootDirection.y < -0.55f)
        {
            shootDirection.y = -1;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Input.GetKey(downKey) || Input.GetKey(rightKey) || Input.GetKey(leftKey) || Input.GetKey(upKey) || shootDirection.x == 1 || shootDirection.x == -1 || shootDirection.y == 1 || shootDirection.y == -1 )
            {
                if (shootDelay) //to make sure you don't move and shoot on the same frame (if you turn you'll shoot the way you're facing right now first)
                {
                    shootDelay = false;
                    return;
                }
                else
                {
                    myProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject; //transform.position gör så att 
                    audioSource.clip = shootSound;
                    audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                    audioSource.Play();
                    timer = fireRate;
                    shootDelay = true;

                }
            }
        }
    }
}
