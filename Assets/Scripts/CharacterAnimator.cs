using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterAnimator : MonoBehaviour
{
    private CharacterController body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.GetMovement().magnitude > 0.1f)
        {
            Vector2 direction = body.GetMovement().normalized;
            float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
            if(direction.x > 0)
            {
                angle *= -1;
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * 1000f);
        }
    }
}
