using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform startpos, endpos;
    public bool spotted;


    // Start is called before the first frame update
    void Start()
    {
        Raycast();
    }

    void Raycast()
    {
        Debug.DrawLine(startpos.position, endpos.position, Color.red);
        spotted = Physics2D.Linecast(startpos.position, endpos.position, 1 << LayerMask.NameToLayer("Player"));


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
