using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Movement Settings: ")]
    public float speedMultipler = 5.0f;
    public float distanceFromPlayer = 5.0f;
    private GameObject player;
    private Vector3 targetDir;

    [Header("Enemy Damage Settings: ")]
    [Range(1, 100)] public float enemyDamage = 10.0f;
    [Range(1, 5)] public float enemyDamageRate = 1.0f;
    private float enemyDamageTimer = 0.0f;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check distance from player
        if (Vector2.Distance(player.transform.position, transform.position) <= distanceFromPlayer)  // Check distance between player and enemy
        {
            // Then Move
            targetDir = player.transform.position - transform.position;                             // Find direction of the player from the current position
            transform.position += targetDir * Time.deltaTime * speedMultipler;                      // Move towards player
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")                               // Check if collided with player
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();  // Find player health

            enemyDamageTimer += Time.deltaTime;                                 // Add time

            if (enemyDamageTimer >= enemyDamageRate)                            // If damage timer exceeds damage rate
            {
                playerHealth.DamageHealth(enemyDamage);                         // Damage player
                enemyDamageTimer = 0.0f;                                        // Reset damage timer when collision stops
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enemyDamageTimer = 0.0f;    // Reset damage timer when collision stops
    }
}
