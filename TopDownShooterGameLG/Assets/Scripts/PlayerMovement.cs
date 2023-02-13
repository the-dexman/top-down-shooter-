using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2f;
    public float bounceSpeed;
    BoxCollider boxCollider;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public delegate void PlayerHit(Transform enemyHitTransform);
    public static PlayerHit playerHit;

    // Start is called before the first frame update
    void Start()
    {
        playerHit += PlayerHitReaction;
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 playerMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        gameObject.transform.Translate(playerMovement.normalized * speed * Time.deltaTime, Space.World);
        



    }

    void PlayerHitReaction(Transform enemyHitTransform)
    {
        Vector3 directionToEnemy = enemyHitTransform.position - gameObject.transform.position;

        gameObject.GetComponent<Rigidbody>().AddForce(directionToEnemy * -1 * bounceSpeed, ForceMode.Impulse);
        
    }
}
