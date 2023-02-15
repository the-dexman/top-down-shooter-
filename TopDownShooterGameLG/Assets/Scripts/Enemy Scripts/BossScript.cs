using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    EnemyMovement enemyMovement;
    EnemyShootScript enemyShootScript;
    public float revealWaitTime;    
    bool phase2 = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        enemyShootScript = gameObject.GetComponent<EnemyShootScript>();
        enemyShootScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMovement.enemyHealth <= 0)
        {
            enemyMovement.animator.SetInteger("animationID", 2);
            Destroy(this);
        }

        if (enemyMovement.enemyHealth < enemyMovement.maxHealth / 2 && phase2 == false)
        {
            enemyMovement.enemyType = 1;
            enemyMovement.animator.SetInteger("animationID", 2);
            enemyMovement.animator.Play("BigBossReveal");
            enemyShootScript.enabled = true;
            phase2 = true;
        }


    }

    private IEnumerator RevealAnimation(float delayBeforeMovement)
    {
        enemyMovement.animator.SetInteger("animationID", 2);
        yield return new WaitForSeconds(delayBeforeMovement);
        enemyMovement.animator.SetInteger("animationID", 1);
    }

}
