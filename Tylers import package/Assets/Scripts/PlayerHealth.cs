using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 50;

    public int KillCounter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            health -= collision.gameObject.GetComponent<EnemyHealth>().damage;

        }

        if (collision.gameObject.tag == "Bullet")
        {

            // health -= collision.gameObject.GetComponent<Bullet>().damage;

        }

    }

}
