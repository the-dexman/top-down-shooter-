using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    public int playerHealth;
    public int deathSceneID;
    public delegate void PlayerDeath();
    public static PlayerDeath playerDeath;

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
            playerDeath.Invoke();
            this.enabled = false;
        }
    }

    void TakeDamage(Transform enemyHitPosition)
    {
        playerHealth -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "medkit")
        {
            if (maxHealth!= playerHealth)
            {
                playerHealth++;
                Debug.Log("HEALED");
                Destroy(other.gameObject);
            }
            
        }
    }
}
