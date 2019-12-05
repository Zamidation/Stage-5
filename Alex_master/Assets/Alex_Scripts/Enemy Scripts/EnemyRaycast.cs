using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public float distance;
    public bool spotted = false;
    public LineRenderer Sight;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;     
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player shot");
            }
            // Sight.SetPosition(1, hit.point);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
           // Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
            // Sight.SetPosition(1, transform.position + transform.right * distance);
        }
        //Sight.SetPosition(0, transform.position);
    }

    
        

    

    
    

}

