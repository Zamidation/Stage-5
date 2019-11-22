using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{ 

    private bool isMovingRight = true;
    private Rigidbody2D rb;



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


    // Update is called once per frame
    void Update()
    {

        if (isMovingRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }



    }
}
