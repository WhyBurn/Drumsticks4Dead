using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathSFX : MonoBehaviour
{

    AudioSource zomSource; 
    [SerializeField] private AudioClip zombieHit1;
    [SerializeField] private AudioClip zombieHit2;
    [SerializeField] private AudioClip zombieHit3;
    [SerializeField] private AudioClip zombieHit4;
    // Start is called before the first frame update

    public void Start()
    {
        zomSource = gameObject.GetComponent<AudioSource>();
    }

    public void zombieDeath()
    {
        int zhitSFX = Random.Range(0, 4);
        zombieHitSFX(zhitSFX);
    }

    void zombieHitSFX(int hitFX)
    {
        if (hitFX == 0)
        {
            zomSource.clip = zombieHit1;
            zomSource.Play();
        }
        else if (hitFX == 1)
        {
            zomSource.clip = zombieHit2;
            zomSource.Play();
        }
        else if (hitFX == 2)
        {
            zomSource.clip = zombieHit3;
            zomSource.Play();
        }
        else
        {
            zomSource.clip = zombieHit4;
            zomSource.Play();
        }
    }
}
