using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEnemyHealth : MonoBehaviour
{
    public Transform reference;

    public TextMesh display;

    // Start is called before the first frame update
    void Start()
    {
        display.text = GetComponentInParent<EnemyHealth>().health.ToString();

        display.alignment = TextAlignment.Center;

        display.anchor = TextAnchor.MiddleCenter;

        display.characterSize = 10f;

        display.fontSize = 100;

        transform.localScale = new Vector3(1 / (float)display.fontSize, 1 / (float)display.fontSize, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {

        display.text = GetComponentInParent<EnemyHealth>().health.ToString();
           
    }
}
