using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public  GameObject powerupPrefab;
    public List<PowerUp> powerup;
    public Dictionary<PowerUp, float> activePowerups = new Dictionary<PowerUp, float>(); // store the key of the vaules 
    private List<PowerUp> keys = new List<PowerUp>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         HandleActivePowerUps();
    }
 
    public void HandleActivePowerUps()
    {
     bool changed = false;
     if (activePowerups.Count>0)
    {
         foreach (PowerUp powerup in keys)
        {
             if(activePowerups[powerup]>0)
             {
                 activePowerups[powerup] -= Time.deltaTime;
             }

            else
            {
                changed = true;
                activePowerups.Remove(powerup);
                powerup.End();
            }
        
        
        }

    }
        if(changed)
        {
                keys = new List<PowerUp>(activePowerups.Keys);
        }
    }
    
    public void ActivatePowerUp(PowerUp powerup)
    {
        if(!activePowerups.ContainsKey(powerup))
            {
                powerup.Start();
                activePowerups.Add(powerup, powerup.duration);
            }
        else
        {
            activePowerups[powerup] += powerup.duration;
        }
        keys = new List<PowerUp>(activePowerups.Keys);// storing the keys into a seperate list. everytime we add a power up where adding a new key to our dictionary
    }

    public GameObject SpawnPowerUp(PowerUp powerup, Vector3 position)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);
        var powerupBehaviour = powerupGameObject.GetComponent<PowerUpBehaviour1>();

        powerupBehaviour.controller = this;
        powerupBehaviour.SetPowerUp(powerup);
        powerupGameObject.transform.position = position;
        return powerupGameObject;
    }
}
