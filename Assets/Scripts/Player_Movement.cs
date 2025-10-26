using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Animator anim;
    public float jumpForce = 100f;
    public float speed;
    public LayerMask groundLayer;
    public Transform jumppoint;
    public float jumprange = 0.1f;
    public float jumpspeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Physics2D.OverlapCircle(transform.position, jumprange, groundLayer))
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    public void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.azure;
        Gizmos.DrawWireSphere(jumppoint.position, jumprange);
    }

}
