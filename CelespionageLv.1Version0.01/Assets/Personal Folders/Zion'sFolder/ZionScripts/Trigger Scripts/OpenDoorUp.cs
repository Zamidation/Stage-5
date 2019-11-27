using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorUp : MonoBehaviour
{
    public GameObject DoorTrigger;
    public GameObject Door;

    Animator DoorAnim;


    void Start()
    {
        DoorAnim = Door.GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OpenDoor (true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OpenDoor (false);
        }
    }

    void OpenDoor(bool state)
    {
        DoorAnim.SetBool("Open", state);
    }    


}
