using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public bool canDash = true;
    public bool isDashing = false;
    public Rigidbody rigidbodyComponent;
    BoxCollider boxCollider;
    public KeyCode dash;
    float playerHorizontal;
    float playerVertical;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame

    void Update()
    {

        Vector2 playerMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("shiz worked");

        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigidbodyComponent.velocity = new Vector2();
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
