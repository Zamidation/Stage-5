using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCameraToScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera maincamera;
    public Transform SetItHere;
    public float SizeAdjustment;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {


        maincamera.GetComponent<CameraFollow>().Scene = true;

        maincamera.transform.position = new Vector3(SetItHere.position.x, SetItHere.position.y, SetItHere.position.z - 16);

        maincamera.orthographicSize = SizeAdjustment;


        }

    }

}
