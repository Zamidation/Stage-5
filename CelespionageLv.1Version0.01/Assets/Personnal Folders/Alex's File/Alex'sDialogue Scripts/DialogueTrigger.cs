using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isPaused = false;
    public GameObject Pause;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPaused)                    //If/Else statements determine if the game paused or not and determines a reaction time for each one
        {
            Pause.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Pause.SetActive(false);
            Time.timeScale = 1f;
        }

        if (collision.gameObject.tag == "Player")
        {
            isPaused = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);       
        }

    }
    
    void Update() //Closes the pause menu and unfreezes time after being clicked.
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Pause.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            Destroy(GameObject.Find("Powerups"));
        }
    }
    

}
