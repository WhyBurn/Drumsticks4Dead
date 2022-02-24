using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : CharacterController
{
    public int playerNumber;

    override public Vector2 GetMovement()
    {
        return (Inputs.playerMovements[playerNumber]);
    }
}
