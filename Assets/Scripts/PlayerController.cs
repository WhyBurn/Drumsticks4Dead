using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : CharacterController
{
    public int playerNumber;
    public float interactDistance;
    public float interactArc;
    public Transform projectileLoc;
    private HeldItem heldItem;

    public HeldItem Held
    {
        get { return (heldItem); }
    }

    override public Vector2 GetMovement()
    {
        return (Inputs.playerMovements[playerNumber]);
    }

    public override void TryAction()
    {
        if(heldItem != null)
        {
            heldItem.transform.position = projectileLoc.position;
            heldItem.transform.rotation = transform.rotation;
        }
        TryInteract();
        TryThrow();
        TryDrop();
    }

    //Throwing logic
    public void TryThrow()
    {
        //This can work for any player. (though we have to manually set what player number this is)
        
        if(Inputs.playerThrowDown[playerNumber])
        {
            //check to see if the object we want to throw exists
            if(heldItem != null)
            {
                heldItem = heldItem.Throw();
            }
            else
            {
                Debug.Log("Chicken does not exist");
            }
        }
    }

    public void TryInteract()
    {
        if (Inputs.playerInteractDown[playerNumber])
        {
            bool foundObject = false;
            RaycastHit2D closest = default;
            for (float angle = interactArc / -2; angle <= interactArc / 2; angle += 1)
            {
                foreach (var hit in Physics2D.RaycastAll(transform.position, Quaternion.Euler(0, 0, angle) * transform.up, interactDistance))
                {
                    if (!foundObject || hit.distance < closest.distance)
                    {
                        HeldItem item = hit.transform.gameObject.GetComponent<HeldItem>();
                        if (hit.transform.gameObject != gameObject && (item == null || (!item.Held && !item.Thrown)))
                        {
                            closest = hit;
                            foundObject = true;
                        }
                    }
                }
            }
            if (foundObject)
            {
                GameObject closestObject = closest.transform.gameObject;
                Interactable closestInteractable = closestObject.GetComponent<Interactable>();
                if (closestInteractable != null)
                {
                    closestInteractable.Interact(gameObject);
                }
            }
        }
    }

    public void RemoveHeldItem()
    {
        heldItem = null;
    }

    public void GrabItem(HeldItem item)
    {
        if(heldItem == null)
        {
            heldItem = item;
            heldItem.Held = true;
        }
        else
        {
            GameObject combo = item.GetCombinationObject(heldItem.itemId);
            if(combo != null)
            {
                Data.deletedItems.Add(heldItem.gameObject);
                Data.deletedItems.Add(item.gameObject);
                heldItem = Instantiate(combo).GetComponent<HeldItem>();
                heldItem.Held = true;
                Data.spawnedItems.Add(heldItem.gameObject);
            }
        }
    }

    //Creates a new object based on the prefab for and holds it.
    public void GrabItem(GameObject itemPrefab)
    {
        if (heldItem == null)
        {
            if (itemPrefab.GetComponent<HeldItem>() != null)
            {
                heldItem = Instantiate(itemPrefab).GetComponent<HeldItem>();
                heldItem.Held = true;
                Data.spawnedItems.Add(heldItem.gameObject);
            }
        }
        else
        {
            if (itemPrefab.GetComponent<HeldItem>() != null)
            {
                GameObject combo = itemPrefab.GetComponent<HeldItem>().GetCombinationObject(heldItem.itemId);
                if (combo != null)
                {
                    Data.deletedItems.Add(heldItem.gameObject);
                    heldItem = Instantiate(combo).GetComponent<HeldItem>();
                    heldItem.Held = true;
                    Data.spawnedItems.Add(heldItem.gameObject);
                }
            }
        }
    }

    public void TryDrop()
    {
        if(Inputs.playerDropDown[playerNumber] && heldItem != null)
        {
            heldItem.Held = false;
            heldItem = null;
        }
    }
}
