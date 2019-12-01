using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public void Interacted()
    {
        if(gameObject.GetComponent<PlatformMoveTrigger>().interaction == true)
        {
            gameObject.GetComponent<PlatformMoveTrigger>().interaction = false;
        }

        else
        {
            gameObject.GetComponent<PlatformMoveTrigger>().interaction = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
