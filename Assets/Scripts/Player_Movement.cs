using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 dashInput;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Animator anim;
    public float jumpForce = 10f;
    public float speed;
    public LayerMask groundLayer;
    public float jumprange = 0.1f;
    private float jumpspeed;
    public float dashForce = 20f;
    public float dashCooldown = 0.5f;
    private float originalGravity;
    public bool isDashing;
    public SpriteRenderer playerSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        if (transform.localScale.x < 0)
        {
            dashForce = -Mathf.Abs(dashForce);
            Debug.Log("Left");
        }
        if (transform.localScale.x > 0)
        {
            dashForce = Mathf.Abs(dashForce);
            Debug.Log("Right");
        }
        if (isDashing == true)
        {
            return;
        }
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        if (moveInput.x > 0 && transform.localScale.x < 0)
        {
            flip();
        }
        else if (moveInput.x < 0 && transform.localScale.x > 0)
        {
            flip();
        }
        float speed = Mathf.Abs(rb.linearVelocity.x);
        anim.SetFloat("speed", speed);
        float jumpspeed = Mathf.Abs(rb.linearVelocity.y);
        anim.SetFloat("jumpspeed", jumpspeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (dashCooldown <= 0)
         StartCoroutine(Dashroutine());
    }
    public void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down,1f, groundLayer);
    }
    IEnumerator Dashroutine()
    {
        isDashing = true;
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(dashForce, 0);
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = originalGravity;
        dashCooldown = 3f;     
        isDashing = false;
    }

    

}
