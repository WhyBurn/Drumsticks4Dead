using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtBox : MonoBehaviour
{
    public CharacterController attachedCharacter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Projectile"))
        {
            Projectile projectile = collision.transform.gameObject.GetComponent<Projectile>();
            HeldItem item = projectile.gameObject.GetComponent<HeldItem>();
            if ((item == null || item.Thrown) && projectile.Team != attachedCharacter.team)
            {
                attachedCharacter.TakeDamage(projectile.damage);
                Destroy(projectile.gameObject);
            }
        }
    }
}
