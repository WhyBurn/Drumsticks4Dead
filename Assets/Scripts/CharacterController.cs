using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    public float maxSpeed;
    public float maxAcceleration;

    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = GetMovement();
        Vector2 targetVelocity = movementVector * maxSpeed;
        float horizontalDifference = targetVelocity.x - body.velocity.x;
        float vertiaclDifference = targetVelocity.y - body.velocity.y;
        if (horizontalDifference > 0)
        {
            horizontalDifference = Mathf.Min(horizontalDifference, maxAcceleration);
        }
        else
        {
            horizontalDifference = Mathf.Max(horizontalDifference, maxAcceleration * -1);
        }
        if (vertiaclDifference > 0)
        {
            vertiaclDifference = Mathf.Min(vertiaclDifference, maxAcceleration);
        }
        else
        {
            vertiaclDifference = Mathf.Max(vertiaclDifference, maxAcceleration * -1);
        }
        body.AddForce(new Vector2(horizontalDifference, vertiaclDifference), ForceMode2D.Force);
    }

    virtual public Vector2 GetMovement()
    {
        return new Vector2(0, 0);
    }
}
