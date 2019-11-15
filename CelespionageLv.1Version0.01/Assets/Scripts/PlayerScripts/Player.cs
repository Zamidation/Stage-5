using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Keyboard Input: ")]
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;

    [Header("Horizontal Speed Settings: ")]
    public float speedMultiplier = 5.0f;    // Play around with this setting to optimize the right speed for the player in the inspector.
    public float maxSpeed = 10.0f;
    public bool useHorizontalPhysicsMovement = true;

    [Header("Jumping Settings: ")]
    public int maxJumps = 1;
    public float jumpPower = 5.0f;          // Play around with this setting to optimize the right height for jumping in the inspector.
    public Transform groundDetection;       // Initialize with the transform that is the empty gameobject that is positioned at the bottom of where your player is positioned.
    public LayerMask ground;                // Check for layer named ground in the inspector.
    private int remainingJumps;
    private Rigidbody2D rb;                 // Used to apply forces with a 2D gameobject
    private bool isGrounded;                // Used to check the space below the player as ground or not
    private bool hasJumped = false;

    [Header("Hazard Damage Settings:")]
    public float hazardDamage = 10.0f;
    [Range(1, 5)] public float hazardDamageRate = 1.0f;
    private float hazardDamageTimer = 0.0f;
    private bool onHazard = false;
    public bool OnHazard { set { onHazard = value; } }

    [Header("Debug Settings: ")]
    public bool debugComponent = false;

    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        remainingJumps = maxJumps;
        rb = GetComponent<Rigidbody2D>();   // Initialize the Rigidbody2D object with this gameobject's Rigidbody2D component that is attached to it in the inspector.
    }

    /// <summary>
    /// Fixed Update is called once per fixed frame.
    /// Use physical behaviors (or anything involving the rigidbody) in this function.
    /// </summary>
    private void FixedUpdate()
    {
        JumpingPhysics();

        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        Vector2 newMovement;                                                                                    // Create a local variable to store the next movement calculation.

        if (Input.GetKey(moveLeft))                                                                             // Check if moveLeft key is pressed.
        {
            if (useHorizontalPhysicsMovement)
            {
                rb.velocity = new Vector2(rb.velocity.x - (Time.fixedDeltaTime * speedMultiplier), rb.velocity.y);
            }
            else
            {
                newMovement = new Vector2(rb.position.x - (Time.deltaTime * speedMultiplier), rb.position.y);   // Move the player along the x-axis using a speed multiplier in the left direction.
                rb.position = newMovement;                                                                      // Set the rigidbody position to the newMovement position that was just calculated.
            }
        }
        if (Input.GetKey(moveRight))                                                                            // Check if moveRight key is pressed.
        {
            if (useHorizontalPhysicsMovement)
            {
                rb.velocity = new Vector2(rb.velocity.x + (Time.fixedDeltaTime * speedMultiplier), rb.velocity.y);
            }
            else
            {
                newMovement = new Vector2(rb.position.x + (Time.deltaTime * speedMultiplier), rb.position.y);   // Move the player along the x-axis using a speed multiplier in the right direction.
                rb.position = newMovement;                                                                      // Set the rigidbody position to the newMovement position that was just calculated.
            }
        }

        // Check to not exceed max velocity
        if (useHorizontalPhysicsMovement)
        {
            if (rb.velocity.x >= maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x <= -maxSpeed)
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
        }
    }

    void JumpingPhysics()
    {
        isGrounded = Physics2D.OverlapCircle(groundDetection.position, 0.1f, ground);                           // Check to see if objects that are layered as Ground are detected within the overlap circle around the empty gameobject ground detection. 

        if (debugComponent)
            Debug.Log("isGrounded: " + isGrounded);

        if (hasJumped)                                                                                          // Check if jump key is pressed.
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);                                           // Add an impulsive force to the rigidbody of the gameobject.
            hasJumped = false;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        Rotate();

        JumpingInput();

        HazardCollision();

        
    }

    void Rotate()
    {
        if (Input.GetKeyDown(moveLeft))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
        if (Input.GetKeyDown(moveRight))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
    }

    void JumpingInput()
    {
        if (isGrounded)                                                                 // Check if player is grounded.
        {
            remainingJumps = maxJumps;                                                  // Reset remainingJumps to the maxJumps allowed

            if (Input.GetKeyDown(jump))                                                 // Check if jump key is pressed.
            {
                hasJumped = true;
                remainingJumps--;
            }
        }
        else
        {
            if (remainingJumps > 0)
            {
                if (Input.GetKeyDown(jump))                                                 // Check if jump key is pressed.
                {
                    hasJumped = true;
                    remainingJumps--;
                }
            }
        }
    }

    void HazardCollision()
    {
        if (onHazard)
        {
            hazardDamageTimer += Time.deltaTime;

            if (hazardDamageTimer >= hazardDamageRate)
            {
                GetComponent<Health>().DamageHealth(hazardDamage);
                hazardDamageTimer = 0.0f;
            }
        }
        else
        {
            hazardDamageTimer = 0.0f;
        }
    }

    
}
