using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEBullet : MonoBehaviour
{
   [Header("Bullet Movement Settings:")]
    public float speedMultiplier = 7.0f;
    public bool useHorizontalPhysicsMovement = true;
    private bool isMovingRight = true;
    private Rigidbody2D rb;

    [Header("Bullet Damage Settings:")]
    [Range(1, 100)] public float bulletDamage = 90.0f;

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
        Destroy(gameObject, 3.0f);

        if (useHorizontalPhysicsMovement)
        {
            rb = GetComponent<Rigidbody2D>();

            if (isMovingRight)
            {
                rb.AddForce(Vector2.right * speedMultiplier, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.left * speedMultiplier, ForceMode2D.Impulse);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!useHorizontalPhysicsMovement)
        {
            if (isMovingRight)
            {
                transform.Translate(Vector2.right * Time.deltaTime * speedMultiplier);
            }
            else
            {
                transform.Translate(Vector2.left * Time.deltaTime * speedMultiplier);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.DamageHealth(bulletDamage);
        }
        else if(collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            playerHealth.DamageHealth(bulletDamage);

        }
        Destroy(gameObject);
    }
}
