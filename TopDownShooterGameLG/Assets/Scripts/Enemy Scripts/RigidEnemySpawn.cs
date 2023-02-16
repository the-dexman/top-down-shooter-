using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidEnemySpawn : MonoBehaviour
{
    //this is for procedual room generation
    public Transform spawnPosition;
    float spawnDistance = 0;
    public float randomExtraSpawnDistance = 0;
    public GameObject[] enemyTypes;

    public int maxEnemySpawns;
    public int minEnemySpawns;

    bool canSpawn = false;

    void Start()
    {
        int random = Random.Range(minEnemySpawns, maxEnemySpawns + 1);
        for (int i = 0; i < random; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        FindNewSpawnLocation();
        int random = Random.Range(0, enemyTypes.Length);
        Instantiate(enemyTypes[random], transform.position, Quaternion.identity);
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

        Vector3 newPosition = spawnPosition.position + new Vector3(xMovement, yMovement, -0.5f);
        transform.position = newPosition;

        Debug.Log("Found new spawn location");
    }


}
