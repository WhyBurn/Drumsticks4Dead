using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : CharacterController
{
    public override void Die()
    {
        Data.deletedZombies.Add(gameObject);
    }
}
