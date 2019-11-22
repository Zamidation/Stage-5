using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlatform : MonoBehaviour
{
    public GameObject platform;

    public Transform spawnPoint;
    //private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Rigidbody2D>().AddForce
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
          GameObject spawnedplatform = Instantiate(platform, spawnPoint.position, spawnPoint.rotation);

            spawnedplatform.name = "TemporaryPlatform";
            Destroy(GameObject.Find("TemporaryPlatform"), 5.0f);
            //spawned = true;
        }


    }
}
