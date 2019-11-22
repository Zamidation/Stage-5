using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoubleJump : MonoBehaviour   //power up actions
{
    private PlayerMovement playerMovement; 

    public void DoubleJumpStartAction(){
        playerMovement.JumpNum += 2;
    }

    public void DoubleJumpEndAction(){
        playerMovement.JumpNum = playerMovement.defaultJump;
    }

}
