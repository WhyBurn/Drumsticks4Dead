using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerInteractable : Interactable
{
    public GameObject chickenObject;

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {

    }

    public override void Interact(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerController>().GrabItem(chickenObject);
    }
}
