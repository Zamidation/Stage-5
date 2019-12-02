using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InteractableDoor : MonoBehaviour
{
    public Vector2 initialPlayerPosition;
    public Transform PlayerStorage;
    
    public Object NextScene;

    public void Interacted()
    {
        //PlayerStorage.position = initialPlayerPosition;
        SceneManager.LoadScene(NextScene.name);   // load a the following scene 
    }

}
