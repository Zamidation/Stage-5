using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   private static GameMaster instance;
   public Vector2 lastCheckPointPosition; // variable used to repersent the last checkpoint the player collide withs

   void Awake()
   {    
    if(instance==null)
    {
        instance = this;
        DontDestroyOnLoad(instance);// wont reset object information on scenes
    }
    else{
        Destroy(gameObject);// makes sure there is not multiple game objects
    }


   }
}
