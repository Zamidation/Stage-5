using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start(){
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update(){

    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
        {
            levelManager.currentCheckPoint = gameObject;
        }
    }
   
}
