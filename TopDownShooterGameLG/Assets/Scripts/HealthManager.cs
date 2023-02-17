using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    public static int playerHealth;
    public float deathDelay;
    public int deathSceneID;
    public delegate void PlayerDeath();
    public static PlayerDeath playerDeath;
    bool hasHealed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.playerHit += TakeDamage;
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hasHealed = false;
        if (playerHealth <= 0)
        {
            Debug.Log("DEATH");
            playerDeath.Invoke();
            StartCoroutine(DeathDelay());
            this.enabled = false;
        }
    }

    void TakeDamage(Transform enemyHitPosition)
    {
        playerHealth -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHealed)
        {
            return;
        }
        hasHealed = true;
        if (other.gameObject.tag == "medkit")
        {
            if (maxHealth != playerHealth)
            {
                playerHealth++;
                Debug.Log("HEALED");
                Destroy(other.gameObject);
            }
            
        }
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene(deathSceneID);
    }
}
