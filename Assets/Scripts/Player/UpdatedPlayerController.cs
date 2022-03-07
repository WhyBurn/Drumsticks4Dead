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
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        //read in the value for movement, should be a 2D vector
        movement = value.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext value)
    {
        Debug.Log("Interact Attempt");
        var closest = Physics2D.Raycast(transform.position, transform.forward, interactDistance);
        GameObject closestObject = closest.transform.gameObject;
        Interactable closestInteractable = closestObject.GetComponent<Interactable>();
        if(closestInteractable != null)
        {
            closestInteractable.Interact(gameObject);
        }
    }
}
