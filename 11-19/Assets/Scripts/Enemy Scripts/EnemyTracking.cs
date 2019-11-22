using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{


    /* This is a proof of concept for a sample turret enemy.
     * This helps me learn:
     * 
     * Raycasting,
     * Transformation,
     * Determining Distance,
     * Timelapses
     */

    public bool FullTracking; // this will be tracking which follows the position of the player, 
                              // if this is false, this will only point in the direction of the player (fighting game style)
    private RaycastHit2D radius; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (FullTracking == true)
        {

            Debug.DrawRay(gameObject.transform.position, GameObject.FindGameObjectWithTag("Player")
            

        }

    }
}
