using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int playerHealth;
    public int deathSceneID;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.playerHit += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("DEATH");
            SceneManager.LoadScene(deathSceneID);
        }
    }

    void TakeDamage(Transform enemyHitPosition)
    {
        playerHealth -= 1;
    }
}
