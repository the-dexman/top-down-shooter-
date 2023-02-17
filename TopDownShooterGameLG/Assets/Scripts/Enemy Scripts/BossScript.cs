using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    EnemyMovement enemyMovement;
    EnemyShootScript enemyShootScript;
    public float revealWaitTime;
    public GameObject portalObject;
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
            enemyMovement.animator.SetInteger("animationID", -1);
            Instantiate(portalObject, transform.position, transform.rotation);
            Destroy(this);
        }

        if (enemyMovement.enemyHealth < enemyMovement.maxHealth / 2 && phase2 == false)
        {
            enemyMovement.enemyType = 1;
            StartCoroutine(RevealAnimation(revealWaitTime));
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

    void BossDoneShooting()
    {
        enemyMovement.animator.SetInteger("animationID", 1);
    }

}
