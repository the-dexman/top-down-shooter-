using System.Collections;
using UnityEngine;

public class DashScriptImport : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    private void Update()
    {
        if (isDashing) //disables movement from player inputs while dashing by finishing the update method instantly if isDashing = true before any other code is able to execute
        {
            return;
        }

        //movement for up and down
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("shift") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("shift") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash()); //used to start the dash coroutine
        }

        Flip();
    }

    private void FixedUpdate() // movement portside and starboard
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) // if facing right but horizontal value is pointing left or vice versa then it will reverse the isfacingright bool
        {
            Vector3 localScale = transform.localScale; //create variable with localscale
            isFacingRight = !isFacingRight; //reverses the variable
            localScale.x *= -1f; //reverse localscale x value
            transform.localScale = localScale; // put variable scale to the gameobjects localscale
        }
    }

    private IEnumerator Dash() //IEnumerator is a return type, its used to commit a certain part of a script, wait for next frame and then execute the next part
                               //tldr, it splits your code up between frames to execute at diffrent times
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale; //stores the rigidbodys gravity onto a variable
        rb.gravityScale = 0f; //makes the rigidbody unaffected by gravity
        rb.velocity = new Vector3(transform.localScale.x * dashingPower, 0f); //localscale.x???
        tr.emitting = true; //related to a trail thing, not necessary
        yield return new WaitForSeconds(dashingTime); //yield return used to indicate a stop point to wait for next frame or wait a certain amount of time,
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}