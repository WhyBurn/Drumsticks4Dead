using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdatedPlayerController : MonoBehaviour
{
    private Vector2 movement;
    public float speed = 3f;
    private Rigidbody2D rb;
    public float interactDistance;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movement * speed;
        Debug.DrawRay(transform.position, transform.up, Color.yellow, interactDistance);
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        //read in the value for movement, should be a 2D vector
        movement = value.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext value)
    {
        Debug.Log("Interact Attempt");
        bool foundObject = false;
        RaycastHit2D closest = default;
        foreach (var hit in Physics2D.RaycastAll(transform.position, transform.up, interactDistance))
        {
            if(!foundObject || hit.distance < closest.distance)
            {
                if(hit.transform.gameObject != gameObject)
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
