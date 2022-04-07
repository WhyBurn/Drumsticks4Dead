using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombs : MonoBehaviour
{
    public Transform[] m_spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNewZombie() {
        int randomIndex = Random.Range(0, m_spawnPoints.Length);
        Transform spawnPoint = m_spawnPoints[randomIndex];
        
        Instantiate(Zombie.prefab.meta, spawnPoint.position, spawnPoint.rotation);
    }
}