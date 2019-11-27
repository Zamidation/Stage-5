using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb; // identifies the existing Rigidbody2d on the gameObject and applies all changes to the local Rigidbody2d

    
    // movement keys
    public KeyCode moveLeft = KeyCode.A; 
    public KeyCode moveRight = KeyCode.D;
    public KeyCode slowMove = KeyCode.LeftShift;
    public KeyCode jump = KeyCode.Space;
    //
            
    public float speedmultiplier = 7.0f; // determines the speed of the player character
    public float jumpPower = 20.0f; // determines velocity of the jump of the player character

    public int JumpNum = 0; // number of jumps in midair the player can have
    public int defaultJump = 0;

    private bool isGrounded; // bool to state whether second jump is possible or not

    public Transform GroundDetection;
    public LayerMask Ground;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Grounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundDetection.position, .6f, Ground);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 newMovement;

        Grounded();

        if (isGrounded)
        {
            JumpNum = 0;
        }


        if (Input.GetKeyDown(moveLeft))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            else if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            }
        }
        else if (Input.GetKeyDown(moveRight))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            }
            else if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }

        if (Input.GetKey(moveLeft) && Input.GetKey(slowMove))
        {
            newMovement = new Vector2(rb.position.x - (Time.deltaTime * speedmultiplier / 2f), rb.position.y);
            rb.position = newMovement;
        }

        else if(Input.GetKey(moveLeft))
        {

            newMovement = new Vector2(rb.position.x - (Time.deltaTime * speedmultiplier), rb.position.y);
            rb.position = newMovement;

        }

        if (Input.GetKey(moveRight) && Input.GetKey(slowMove))
        {
            newMovement = new Vector2(rb.position.x + (Time.deltaTime * speedmultiplier / 2f), rb.position.y);
            rb.position = newMovement;
        }

        else if (Input.GetKey(moveRight))
        {

            newMovement = new Vector2(rb.position.x + (Time.deltaTime * speedmultiplier), rb.position.y);
            rb.position = newMovement;

        }

        if(Input.GetKeyDown(jump))
        {

            if (isGrounded)
            {
                newMovement = new Vector2(rb.velocity.x, jumpPower);
                rb.velocity = newMovement;
            }

            else if (JumpNum < 1)
            {
                JumpNum = JumpNum + 1;
                newMovement = new Vector2(rb.velocity.x, jumpPower);
                rb.velocity = newMovement;
            }

        }

    }
}
