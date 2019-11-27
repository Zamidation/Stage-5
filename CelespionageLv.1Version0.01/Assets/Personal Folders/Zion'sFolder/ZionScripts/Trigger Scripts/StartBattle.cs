using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{

    public GameObject ground; //used to generate the ground platforms on trigger
    public GameObject enemies; // used to generate the enemies to make the battle start

    public GameObject platformafterbattle; // create the platform after battle ends


    public Transform groundposition1;
    public Transform groundposition2;
    public Transform groundposition3;

    public Transform enemyposition1;
    public Transform enemyposition2;
    public Transform enemyposition3;
    public Transform enemyposition4;
    public Transform enemyposition5;
    public Transform enemyposition6;

    public GameObject platformDelete; // after the battle is over, the regular ground platform will delete, and the platform will appear instead

    private bool startofbattle = false;

    private bool endofbattle = false;

    private int beforekillcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().KillCounter == beforekillcount + 6 && endofbattle == false)
        {
            Instantiate(platformafterbattle, platformDelete.transform.position, platformDelete.transform.rotation);
            Destroy(platformDelete);
            endofbattle = true;

            GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().Scene = false;
                       
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && startofbattle == false)
        {
            beforekillcount = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().KillCounter;

            Instantiate(ground, groundposition1.position, groundposition1.rotation);
            Instantiate(ground, groundposition2.position, groundposition2.rotation);
            Instantiate(ground, groundposition3.position, groundposition3.rotation);

            Instantiate(enemies, enemyposition1.position, enemyposition1.rotation);
            Instantiate(enemies, enemyposition2.position, enemyposition2.rotation);
            Instantiate(enemies, enemyposition3.position, enemyposition3.rotation);
            Instantiate(enemies, enemyposition4.position, enemyposition4.rotation);
            Instantiate(enemies, enemyposition5.position, enemyposition5.rotation);
            Instantiate(enemies, enemyposition6.position, enemyposition6.rotation);

            startofbattle = true;

        }

    }

}
