
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//unity events put one or more function in the inspector.
 // allows powerup can be changed in the inspector
public class PowerUp 
{
   
    public string name;

   
    public float duration;

   
    public UnityEvent startAction;

   
    public UnityEvent endAction;

    public void End()
    {
        if(endAction != null)
            endAction.Invoke();
    }

    public void Start()
    {
        if(startAction != null)
            startAction.Invoke();
    }
    
}
// used to be stored in out power up behavours