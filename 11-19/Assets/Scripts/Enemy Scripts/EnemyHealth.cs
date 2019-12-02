using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100; // can change
    public int damage = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(health <= 0)
        {
            Destroy(gameObject); // destroys in .2 seconds

            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().KillCounter++;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }

        if(collision.gameObject.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }

        //Debug.Log("Enemy Health is: " + health);

    }


}
