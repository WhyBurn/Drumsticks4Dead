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

    public AudioSource chickenSpeaker;
    public AudioSource fryerSpeaker;
    public AudioClip overcooked;
    public AudioClip cooked;
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
            fryerSpeaker.mute = false;
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
            {
                //If we're here, we know our chicken has been overcooked.
                timerText.text = ">:(";
                
            }
                
            fryingItem.transform.position = transform.position;
        }
        else
        {
            timerText.text = "";
            fryerSpeaker.mute = true;
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
