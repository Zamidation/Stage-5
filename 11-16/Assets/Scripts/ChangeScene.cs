using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int index;
    public string levelname;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // trigger whene the collider box collides with a game object with the player Tag
        {
            SceneManager.LoadScene(index); // sets an index for how many scene  it can hold
            SceneManager.LoadScene("FirstScene");   // load a the following scene name 
                
        }   
    }
}
