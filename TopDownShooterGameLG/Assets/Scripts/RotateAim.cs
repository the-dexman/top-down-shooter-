using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateAim : MonoBehaviour
{
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode leftKey;

    


    public Vector3 direction;

    // Start is called before the first frame update

    ControllerActions controllerActions;
    Vector2 shootDirection;
    public int time;

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

    void Start()
    {
        HealthManager.playerDeath += RemoveGun;
    }

    // Update is called once per frame
    void Update()
    {
        //yandere dev code my beloved
        if (shootDirection.x <= 0.5f && shootDirection.x >= 0)
        {
            shootDirection.x = 0;
        }
        else if (shootDirection.x >= -0.5f && shootDirection.x <= 0)
        {
            shootDirection.x = 0;
        }
        else if (shootDirection.x > 0.5f)
        {
            shootDirection.x = 1;
        }
        else if (shootDirection.x < -0.5f)
        {
            shootDirection.x = -1;
        }

        if (shootDirection.y <= 0.5f && shootDirection.y >= 0)
        {
            shootDirection.y = 0;
        }
        else if (shootDirection.y >= -0.5f && shootDirection.y <= 0)
        {
            shootDirection.y = 0;
        }
        else if (shootDirection.y > 0.5f)
        {
            shootDirection.y = 1;
        }
        else if (shootDirection.y < -0.5f)
        {
            shootDirection.y = -1;
        }

        if (Input.GetKey(rightKey) || shootDirection.x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        if (Input.GetKey(downKey) || shootDirection.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetKey(leftKey) || shootDirection.x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        if (Input.GetKey(upKey) || shootDirection.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (shootDirection.x == -1 && shootDirection.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 45);
        }
        if (shootDirection.x == 1 && shootDirection.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if (shootDirection.x == 1 && shootDirection.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (shootDirection.x == -1 && shootDirection.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, -45);
        }


        /*
        if (Input.GetKey(leftKey) || shootDirection.x == -1 && Input.GetKey(upKey) || shootDirection.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 45);
        }
        if (Input.GetKey(rightKey) || shootDirection.x == 1 && Input.GetKey(upKey) || shootDirection.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if (Input.GetKey(rightKey) || shootDirection.x == 1 && Input.GetKey(downKey) || shootDirection.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (Input.GetKey(leftKey) || shootDirection.x == -1 && Input.GetKey(downKey) || shootDirection.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, -45);
        }
        */
    }
    void RemoveGun()
    {
        gameObject.SetActive(false);
    }
}
