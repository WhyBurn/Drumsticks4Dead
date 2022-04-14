using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombs : MonoBehaviour
{
    public GameObject m_zombie;
    public Transform[] m_spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewZombie();
        SpawnNewZombie();
        SpawnNewZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNewZombie() {
        // int randomSpot = Random.Next(0, 2);
        Instantiate(m_zombie, m_spawnPoints[0].transform.position, Quaternion.identity);
        Instantiate(m_zombie, m_spawnPoints[1].transform.position, Quaternion.identity);
    }
}