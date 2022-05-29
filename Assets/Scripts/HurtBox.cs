using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HurtBox : MonoBehaviour
{
    public CharacterController attachedCharacter;
    public float[] damageMultipliers;

    [SerializeField] private AudioSource zombieHit1;
    [SerializeField] private AudioSource zombieHit2;
    [SerializeField] private AudioSource zombieHit3;
    [SerializeField] private AudioSource zombieHit4;


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
                int zhitSFX = Random.Range(0, 4);
                attachedCharacter.TakeDamage(Mathf.CeilToInt(projectile.damage * damageMultipliers[(int)projectile.damageType]));
                Destroy(projectile.gameObject);
                zombieHitSFX(zhitSFX);
            }
        }
    }

    void zombieHitSFX(int hitFX)
    {
        if(hitFX == 0)
        {
            zombieHit1.Play();
        }
        else if(hitFX == 1)
        {
            zombieHit2.Play();
        }
        else if (hitFX == 2)
        {
            zombieHit3.Play();
        }
        else
        {
            zombieHit4.Play();
        }
    }
}
