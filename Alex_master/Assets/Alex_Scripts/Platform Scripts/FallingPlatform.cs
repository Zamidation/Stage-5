using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    private float fallDelay = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
       yield return new WaitForSeconds(fallDelay);
       rb.isKinematic = false;

        Destroy(gameObject, 5.0f);

        yield return 0; 


    }
}
