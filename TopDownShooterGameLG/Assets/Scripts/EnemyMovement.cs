using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    public GameObject playerObject;
    public float movementSpeed;

    Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = playerObject.transform.position - gameObject.transform.position;

        

        gameObject.transform.Translate(playerDirection.normalized * movementSpeed * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == playerObject)
        {
            PlayerMovement.playerHit(gameObject.transform);
        }

    }
}
