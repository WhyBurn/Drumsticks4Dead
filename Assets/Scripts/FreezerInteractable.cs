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
        GameObject chicken = Instantiate(chickenObject);
        playerObject.GetComponent<PlayerController>().GrabItem(chicken.GetComponent<HeldItem>());
    }
}
