using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    public GameObject playerObject;
    public float movementSpeed;
    public int enemyType;
    public float rangedEnemyDistance;

    Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        HealthManager.playerDeath += PlayerDied;
    }

    // Update is called once per frame
    void Update()
    {


        playerDirection = playerObject.transform.position - gameObject.transform.position;

        if (playerDirection.x >= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (enemyType == 0)
        {
            BasicMeleeEnemy();
        }
        if (enemyType == 1)
        {
            BasicRangedEnemy();
        }


    }

    void PlayerDied()
    {
        this.enabled = false;
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
}
