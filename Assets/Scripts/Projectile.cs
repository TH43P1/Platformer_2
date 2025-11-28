using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    public GameObject bow;
    public Vector2 worldPosition;
    public Vector2 aimDirection;
    private float angle;
    public GameObject arrow;
    public GameObject arrowInst;
    public Transform arrowSpawnpoint;
    public float rotationOffset;
    public float arrowspeed = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Crouch(InputAction.CallbackContext context)
    { 
     if (context.performed)
        {
            BowShooting();
        }
    }
    void FixedUpdate()
    {
        BowRotation();
    }

    public void BowRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        aimDirection = (worldPosition - (Vector2)bow.transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
        bow.transform.rotation = Quaternion.Euler(0, 0, -angle - rotationOffset);

    }

    public void BowShooting()
    {
        arrowInst = Instantiate(arrow, arrowSpawnpoint.position, bow.transform.rotation);

        Rigidbody2D rb = arrowInst.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = aimDirection * arrowspeed;
        }

    }  

}   


