using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : CharacterController
{
    public int playerNumber;
    public float interactDistance;

    override public Vector2 GetMovement()
    {
        return (Inputs.playerMovements[playerNumber]);
    }

    override public void TryInteract()
    {
        if (Inputs.playerInteractDown[playerNumber])
        {
            bool foundObject = false;
            RaycastHit2D closest = default;
            foreach (var hit in Physics2D.RaycastAll(transform.position, transform.up, interactDistance))
            {
                if (!foundObject || hit.distance < closest.distance)
                {
                    if (hit.transform.gameObject != gameObject)
                    {
                        closest = hit;
                        foundObject = true;
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
}
