using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveTrigger : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed = 2f;

    public bool interaction = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(interaction == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        }

        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

    }


    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && interaction == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            
            Debug.Log("Collion Made");

        }
    }
    */
}
