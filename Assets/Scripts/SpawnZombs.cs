using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombs : MonoBehaviour
{
    //public GameObject m_zombie;
    public SpawningRound spawningRound;
    public Transform[] m_spawnPoints;
    
    private float nextSpawn = 0f;
    private Transform currentPoint;
    private int waveIndex;
    private int zombiesFromWave;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn += Time.deltaTime;
        if(waveIndex < 0 || (waveIndex < spawningRound.waves.Length && zombiesFromWave >= spawningRound.waves[waveIndex].spawningObjects.Length)) {
            if(nextSpawn >= spawningRound.waveDelays[waveIndex + 1])
            {
                nextSpawn = 0f;
                zombiesFromWave = 0;
                ++waveIndex;
                currentPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)];
            }
        }
        else if(waveIndex < spawningRound.waves.Length)
        {
            if(nextSpawn >= spawningRound.waves[waveIndex].spawnDelay)
            {
                nextSpawn -= spawningRound.waves[waveIndex].spawnDelay;
                SpawnNewZombie();
                ++zombiesFromWave;
            }
        }
        else
        {
            Data.doneSpawning = true;
        }
    }

    public void Reset()
    {
        waveIndex = -1;
        Data.doneSpawning = false;
        zombiesFromWave = 0;
        currentPoint = null;
    }

    void SpawnNewZombie() {
        GameObject zombieObject = Instantiate(spawningRound.waves[waveIndex].spawningObjects[zombiesFromWave], currentPoint.position, Quaternion.identity);
        Data.spawnedZombies.Add(zombieObject);
    }
}