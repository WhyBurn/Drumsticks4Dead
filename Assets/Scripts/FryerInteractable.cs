using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryerInteractable : Interactable
{
    //For our timer
    public GameObject timer;

    private HeldItem fryingItem;
    private float fryTime;
    private TextMesh timerText;
    private MeshRenderer timerMesh;
    public override void OnStart()
    {
        fryingItem = null;
        fryTime = 0;

        timerText = timer.GetComponent<TextMesh>();
        timerMesh = timer.GetComponent<MeshRenderer>();
    }

    public override void OnUpdate()
    {
        if(fryingItem != null)
        {
            if (fryingItem.fryedVersion != null)
            {
                timerText.text = ((int)(fryingItem.fryTime - fryTime) + 1).ToString();
                fryTime += Time.deltaTime;
                if (fryTime >= fryingItem.fryTime)
                {
                    GameObject fried = Instantiate(fryingItem.fryedVersion);
                    Data.deletedItems.Add(fryingItem.gameObject);
                    fryingItem = fried.GetComponent<HeldItem>();
                    fryTime = 0;
                    Data.spawnedItems.Add(fried.gameObject);
                }
            }
            else
                //If we're here, we know our chicken has been overcooked.
                timerText.text = ">:(";
            fryingItem.transform.position = transform.position;
        }
        else
        {
            timerText.text = "";
        }
    }

    public override void Interact(GameObject playerObject)
    {
        PlayerController controller = playerObject.GetComponent<PlayerController>();
        if (fryingItem == null)
        {
            timerText.text = "";
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
