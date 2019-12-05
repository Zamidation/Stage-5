using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour1 : MonoBehaviour
{
    public PowerUpController controller;
    
    [SerializeField]
    private PowerUp powerup;

    private Transform transform_;
    
  
    // Start is called before the first frame update
    private void Awake()
    {
        transform_ = transform;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ActivatePowerUp();
            gameObject.SetActive(false);
        }
    }
    
    // Update is called once per frame
    private void ActivatePowerUp()
    {
        //controller.ActivatePowerUp(powerup);
    }

    public void SetPowerUp(PowerUp powerup)
    {
        this.powerup = powerup;
        gameObject.name = powerup.name;
    }






}
