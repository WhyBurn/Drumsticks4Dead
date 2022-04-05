using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer_Health : MonoBehaviour
{
    [SerializeField]
    private double currentHealth;
    [SerializeField]
    private double maxHealth = 100.0;
    [SerializeField]
    private double damageDelt = 1.0;
    [SerializeField]
    private float damageTimer = 1.0f;
    List<GameObject> collidedObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(damageTimer >= 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie" && damageTimer <= 0)
        {
           
            if (!collidedObjects.Contains(collision.gameObject))
            {
                collidedObjects.Add(collision.gameObject);
            }
            freezerTakeDamage();

        }
    }

    void freezerTakeDamage()
    {
        int num = collidedObjects.Count;
        damageTimer = 1.0f;
        currentHealth -= (num * damageDelt);
        freezerDestroyed();
    }

    void freezerDestroyed()
    {
        if (currentHealth < 1)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
    }
}