using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{   
    public float UpTimer = 10.0f;// a variable that shows the player can only remain on the platform for 10 seconds
    public bool debugComponet = false;
    public float TurnaroundTimer = 5.0f;
    public float DownTimer = 10.0f;
    //private bool  IsGoingDown = false;

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(debugComponet)
            Debug.Log(gameObject.name + " Time Left: " + UpTimer);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       
    }
//can be used as a elevater ,aoe attaack,continous damage loop
//trigger check as long  as something goes threw it but activates as long as it connects
    private void OnTriggerStay2D(Collider2D collision) // when the trigger has been entering with anything twith player tag it will tranform by translating downaward 
    {
       if (collision.gameObject.tag == "Player")
       {
           transform.Translate(new Vector2(0, -2.0f *Time.deltaTime));
           UpTimer -= Time.deltaTime;
           if(UpTimer <= 0)
            {
                transform.Translate(new Vector2(0, 2.0f*Time.deltaTime));
                //IsGoingDown = true;
            }
       }
    }
    
}
