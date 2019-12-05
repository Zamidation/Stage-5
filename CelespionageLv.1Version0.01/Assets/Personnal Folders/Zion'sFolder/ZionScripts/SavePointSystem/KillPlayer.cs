using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will occur when ever the player dies [attach to any game object that can damage the player]
public class KillPlayer : MonoBehaviour
{
    
    public LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager =  FindObjectOfType<LevelManager>(); // set the level manager to find other gamobjects set to level manager has to be set manaually in unity.
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            levelManager.RespawnPlayer();
            
        }
    
    }
    
}
