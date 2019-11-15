using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [Header("Debug Settings:")]
    public bool debugComponent = false;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                               // Check if collided with player
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.OnHazard = true;

            if (debugComponent)
                Debug.Log("player.OnHazard: " +  true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                               // Check if collided with player
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.OnHazard = false;

            if (debugComponent)
                Debug.Log("player.OnHazard: " + false);
        }
    }
}
