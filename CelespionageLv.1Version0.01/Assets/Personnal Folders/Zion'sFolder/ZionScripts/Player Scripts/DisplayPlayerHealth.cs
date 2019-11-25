using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayerHealth : MonoBehaviour
{

    public TextMesh display;
    public Transform reference;

    // Start is called before the first frame update
    void Start()
    {
        display.text = GetComponentInParent<PlayerHealth>().health.ToString();

        display.alignment = TextAlignment.Center;

        display.anchor = TextAnchor.MiddleCenter;

        display.characterSize = 10f;

        display.fontSize = 100;

        reference.transform.localScale = new Vector3(1 / (float)display.fontSize, 1 / (float)display.fontSize, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {

        display.text = GetComponentInParent<PlayerHealth>().health.ToString();

        
        if (Input.GetKeyDown("a") && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        else if (Input.GetKeyDown("d") && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        

    }
}
