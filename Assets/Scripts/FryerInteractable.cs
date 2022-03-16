using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryerInteractable : Interactable
{
    public override void OnStart()
    {
        
    }

    public override void OnUpdate()
    {

    }

    public override void Interact(GameObject playerObject)
    {
        PlayerController controller = playerObject.GetComponent<PlayerController>();
        if (controller.Held != null && controller.Held.FryedVersion != null)
        {
            GameObject fried = controller.Held.FryedVersion;
            controller.RemoveHeldItem();
            controller.GrabItem(fried);
        }
    }
}
