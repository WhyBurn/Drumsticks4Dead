using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Movement : CharacterController
{
    [SerializeField]
    public float speed = 12.0f;
    [SerializeField] private GameObject TestFreezer;

    public Transform target;

    // Start is called before the first frame update
    public override void OnStart()
    {
        
       //  target = TestFreezer.transform;
    }

    // Update is called once per frame
    public override Vector2 GetMovement()
    {
        target = TestFreezer.transform;
        // float step = speed * Time.deltaTime;
        //  transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        return (target.position - transform.position).normalized;
    }

    public override void Die()
    {
        Data.deletedZombies.Add(gameObject);
    }
}
