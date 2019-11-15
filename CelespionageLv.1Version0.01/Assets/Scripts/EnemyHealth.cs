using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{ 
    [Header("Health Settings:")]
    [Range(100, 200)]   public float maxHealth = 100.0f;
    public bool destroyOnDeath = true;
    private float currentHealth;

    [Header("Debug Settings:")]
    public bool debugComponent = false;
    // Start is called before the first frame update
    void Start()
    {
         currentHealth = maxHealth;    // Initialize current health with max health.

        if (debugComponent)
            Debug.Log(gameObject.name + " Health: " + currentHealth + "/" + maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
         if (currentHealth <= 0)
        {
            currentHealth = 0;

            if (destroyOnDeath)
            {
                Destroy(gameObject);    // You can set a time to destroy for room to play a death animation.  Destroy(gameObject, 2.5f);
                
            }
        }
        
        else if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void DamageHealth(float damage)
    {
        currentHealth -= damage;

        if (debugComponent)
            Debug.Log(gameObject.name + " Health: " + currentHealth + "/" + maxHealth);
    }
}
