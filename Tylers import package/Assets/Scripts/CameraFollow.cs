using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    public bool Scene = false;

    public float defaultsize = 10;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Scene == false)
        {

            gameObject.GetComponent<Camera>().orthographicSize = defaultsize;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 16);

        }



    }
}
