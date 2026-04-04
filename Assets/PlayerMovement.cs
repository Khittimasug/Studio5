using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float maxSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Vector3 movement;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isGrounded;

    public GameObject chronoSkill;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // A/D → X axis , W/S → Z axis
        float moveX = Input.GetAxisRaw("Horizontal"); // A, D
        float moveZ = Input.GetAxisRaw("Vertical");   // W, S

        movement = new Vector3(moveX, 0f, moveZ);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(chronoSkill,gameObject.transform.position,gameObject.transform.rotation);
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Animation state
        if (Input.GetMouseButton(0))
        {
            //anim.SetInteger("State", 4);
        }
        else if (!isGrounded)
        {
            anim.SetInteger("State", 3); // Jump
        }
        else if (movement != Vector3.zero)
        {
            anim.SetInteger("State", 1); // Walk
        }
        else
        {
            anim.SetInteger("State", 0); // Idle
        }

        // Flip ซ้าย-ขวาเฉพาะตอนเดินแกน X
        if (moveX > 0) sprite.flipX = false;
        else if (moveX < 0) sprite.flipX = true;
    }

    void FixedUpdate()
    {
        // Raycast ลงด้านล่างเพื่อตรวจพื้น
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        // AddForce ให้ Rigidbody
        rb.AddForce(movement.normalized * moveForce, ForceMode.Acceleration);

        // จำกัดความเร็ว
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
    }
}
