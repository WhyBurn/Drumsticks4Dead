using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChickenItem : HeldItem
{
    public float throwSpeed;
    public float lastingTime;
    private Rigidbody2D rb;

    public override void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override HeldItem Throw()
    {
        rb.AddForce(rb.transform.up * throwSpeed, ForceMode2D.Impulse);
        GetComponent<Projectile>().Team = 0;
        Thrown = true;
        //Destroy this projectile after a few seconds
        Destroy(gameObject, lastingTime);

        Held = false;

        return (null);
    }
}
