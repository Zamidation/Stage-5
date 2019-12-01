using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject currentInteractableObject = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Interactable"))
        {
            Debug.Log("Interacting With " + collision.name);
            currentInteractableObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            if(collision.gameObject == currentInteractableObject)
            {
                currentInteractableObject = null; 
            }
            
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractableObject)
        {
            currentInteractableObject.SendMessage("Interacted");
        }

    }
}
