using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int playerHealth;

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
        }
    }

    void TakeDamage(Transform enemyHitPosition)
    {
        playerHealth -= 1;
    }
}
