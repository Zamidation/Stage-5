using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speedmultiplier = 5.0f;

    private bool isMovingRight = true;
    private Rigidbody2D rb;

    public int damage = 5;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player.transform.localScale.x > 0)
        {
            isMovingRight = true;            
        }

        else if (player.transform.localScale.x < 0)
        {
            isMovingRight = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 5.0f);

        
    }


    // Update is called once per frame
    void Update()
    {

        if (isMovingRight)
        {
            transform.Translate(Vector2.right * (Time.deltaTime / 2) * speedmultiplier);
        }

        else
        {
            transform.Translate(Vector2.left * (Time.deltaTime /2) * speedmultiplier);
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }

}
