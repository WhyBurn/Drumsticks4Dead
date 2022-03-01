using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdatedPlayerController : MonoBehaviour
{
    private Vector2 movement;
    public float speed = 3f;
    private Rigidbody2D rb;

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
}
