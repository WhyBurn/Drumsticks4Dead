using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeldItem))]
public class PickUp : Interactable
{
    private HeldItem held;

    public override void OnStart()
    {
        held = GetComponent<HeldItem>();
    }

    public override void OnUpdate()
    {

    }

    public override void Interact(GameObject playerObject)
    {
        if (!held.Held)
        {
            playerObject.GetComponent<PlayerController>().GrabItem(held);
            held.Held = true;
        }
    }
}
