using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    public Transform playerTransform;
    public Camera mainCamera;
    public float spawnDistance;
    public float randomExtraSpawnDistance;
    float spawnTimer;
    float spawnTimerLength;
    public float spawnTimerLengthMinimum;
    public float spawnTimerLengthMax;
    public GameObject[] enemyTypes;

    bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimerLength = Random.Range(spawnTimerLengthMinimum, spawnTimerLengthMax);
    }

    // Update is called once per frame
    void Update()
    {

        spawnTimer += Time.deltaTime;



        if (spawnTimer > spawnTimerLength)
        {
            FindNewSpawnLocation();
            int random = Random.Range(0, enemyTypes.Length);
            Instantiate(enemyTypes[random], transform.position, Quaternion.identity);
            spawnTimerLength = Random.Range(spawnTimerLengthMinimum, spawnTimerLengthMax);
            spawnTimer = 0;

        }
    }

    void FindNewSpawnLocation()
    {
        int[] directionMultipliers = new int[] { -1, 1 };

        int randomDirection = directionMultipliers[Random.Range(0, 2)];
        float randomAdditionalDistance = Random.Range(1.0f, randomExtraSpawnDistance);
        float xMovement = spawnDistance * randomDirection + randomAdditionalDistance * randomDirection;

        randomDirection = directionMultipliers[Random.Range(0, 2)];
        randomAdditionalDistance = Random.Range(1.0f, randomExtraSpawnDistance);
        float yMovement = spawnDistance * randomDirection + randomAdditionalDistance * randomDirection;

        Vector3 newPosition = playerTransform.position + new Vector3(xMovement, yMovement, 0);
        transform.position = newPosition;

        Debug.Log("Found new spawn location");
    }


}



