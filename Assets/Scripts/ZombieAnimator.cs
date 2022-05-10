using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = transform.position - position;
        if (difference.magnitude > Time.deltaTime)
        {
            Vector2 direction = difference.normalized;
            float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
            if (direction.x > 0)
            {
                angle *= -1;
            }
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        position = transform.position;
    }
}
