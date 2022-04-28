using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombs : MonoBehaviour
{
    public GameObject m_zombie;
    public Transform[] m_spawnPoints;
    private float nextSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Data.doneSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextSpawn <= Time.time) {
            nextSpawn = Time.time + 10f;
            SpawnNewZombie();
        }
    }

    void SpawnNewZombie() {
        int randomSpot = Random.Range(0, m_spawnPoints.Length);
        GameObject zombieObject = Instantiate(m_zombie, m_spawnPoints[randomSpot].transform.position, Quaternion.identity);
        Data.spawnedZombies.Add(zombieObject);
    }
}