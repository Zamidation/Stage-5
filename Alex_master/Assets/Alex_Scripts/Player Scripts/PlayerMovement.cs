using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    int maxextrajump;


    public Transform groundDetection;
    public LayerMask ground;

    public float speedMultiplier = 5.0f;
    public float jumpPower = 5.0f;



    private bool doublejump;

    private Rigidbody2D rb;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {




    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMovement;

        if (Input.GetKey(moveLeft))
        {
            AudioManager.instance.PlaySFX(3);
            newMovement = new Vector2(rb.position.x - (Time.deltaTime * speedMultiplier), rb.position.y);
            rb.position = newMovement;
        }
        if (Input.GetKey(moveRight))
        {
            AudioManager.instance.PlaySFX(3);
            newMovement = new Vector2(rb.position.x + (Time.deltaTime * speedMultiplier), rb.position.y);
            rb.position = newMovement;
        }

        isGrounded = Physics2D.OverlapCircle(groundDetection.position, 0.1f, ground);

        Debug.Log("isGrounded: " + isGrounded);
        if (isGrounded)
        {
            doublejump = true;
        }
        if (Input.GetKeyDown(jump))
        {

            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpPower;
            }
            else
            {
                if (doublejump)
                {
                    AudioManager.instance.PlaySFX(0);
                    rb.velocity = Vector2.up * jumpPower;
                    doublejump = false;
                }
            }


        }




    }
}
