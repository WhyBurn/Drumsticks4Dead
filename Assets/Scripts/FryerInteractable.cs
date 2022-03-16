using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryerInteractable : Interactable
{
    private HeldItem fryingItem;
    private float fryTime;

    public override void OnStart()
    {
        fryingItem = null;
        fryTime = 0;
    }

    public override void OnUpdate()
    {
        if(fryingItem != null)
        {
            if (fryingItem.fryedVersion != null)
            {
                fryTime += Time.deltaTime;
                if (fryTime >= fryingItem.fryTime)
                {
                    GameObject fried = Instantiate(fryingItem.fryedVersion);
                    Destroy(fryingItem.gameObject);
                    fryingItem = fried.GetComponent<HeldItem>();
                    fryTime = 0;
                }
            }
            fryingItem.transform.position = transform.position;
        }
    }

    public override void Interact(GameObject playerObject)
    {
        PlayerController controller = playerObject.GetComponent<PlayerController>();
        if (fryingItem == null)
        {
            if (controller.Held != null && controller.Held.fryedVersion != null)
            {
                fryingItem = controller.Held;
                controller.RemoveHeldItem();
            }
        }
        else
        {
            if(controller.Held == null)
            {
                controller.GrabItem(fryingItem);
                fryingItem = null;
                fryTime = 0;
            }
        }
    }
}
