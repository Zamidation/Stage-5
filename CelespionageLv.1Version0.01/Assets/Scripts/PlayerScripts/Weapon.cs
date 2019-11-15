using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Fireball;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
        
        else if(Input.GetButtonDown("Fire2"))
        {
            Instantiate(Fireball, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
