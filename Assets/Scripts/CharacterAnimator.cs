using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterAnimator : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.magnitude > 0.1f)
        {
            Vector2 direction = body.velocity.normalized;
            float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
            if(direction.x > 0)
            {
                angle *= -1;
            }
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
