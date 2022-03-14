using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : CharacterController
{
    public int playerNumber;
    public float interactDistance;
    public GameObject chickenProjectile;
    public Transform projectileLoc;
    public float projectileSpeed = 10f;
    public float lastingTime = 10f;

    override public Vector2 GetMovement()
    {
        return (Inputs.playerMovements[playerNumber]);
    }

    //Throwing logic
    public override void TryThrow()
    {
        //This can work for any player. (though we have to manually set what player number this is)
        
        if(Inputs.playerThrowDown[playerNumber])
        {
            //check to see if the object we want to throw exists
            if(chickenProjectile != null)
            {
                //Debug.Log("Chicken Exists");

                //Instantiate the chicken object
                var proj = (GameObject)Instantiate(chickenProjectile, projectileLoc.transform.position, projectileLoc.transform.rotation);

                //store the projectile's rigidbody
                Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();

                //give this projectile some velocity
                if (rb)
                {
                    rb.AddForce(rb.transform.up * projectileSpeed, ForceMode2D.Impulse);
                }

                //Destroy this projectile after a few seconds
                Destroy(proj, lastingTime);
            }
            else
            {
                Debug.Log("Chicken does not exist");
            }
        }
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
