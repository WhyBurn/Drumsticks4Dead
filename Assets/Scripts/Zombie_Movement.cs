using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Movement : MonoBehaviour
{
    [SerializeField]
    public float speed = 12.0f;
    [SerializeField] private GameObject TestFreezer;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
         target = TestFreezer.transform;
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.LookAt(target);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
