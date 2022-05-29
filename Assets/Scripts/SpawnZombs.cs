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

    //Zombie Spawn SFX
    [SerializeField] private AudioSource zombieSpawnSFX_1;
    [SerializeField] private AudioSource zombieSpawnSFX_2;
    [SerializeField] private AudioSource zombieSpawnSFX_3;
    [SerializeField] private AudioSource zombieSpawnSFX_4;
    [SerializeField] private AudioSource zombieSpawnSFX_5;
    

    // Start is called before the first frame update
    void Start()
    {
        Data.spawnTime = spawningRound.CalculateSpawnTime();
        ResetSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.reset)
        {
            ResetSpawning();
        }
        else
        {
            nextSpawn += Time.deltaTime;
            if (waveIndex < 0 || (waveIndex < spawningRound.waves.Length - 1 && zombiesFromWave >= spawningRound.waves[waveIndex].spawningObjects.Length))
            {
                if (nextSpawn >= spawningRound.waveDelays[waveIndex + 1])
                {
                    nextSpawn = 0f;
                    zombiesFromWave = 0;
                    ++waveIndex;
                    currentPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)];
                }
            }
            else if (waveIndex < spawningRound.waves.Length && zombiesFromWave < spawningRound.waves[waveIndex].spawningObjects.Length)
            {
                if (nextSpawn >= spawningRound.waves[waveIndex].spawnDelay)
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
    }

    public void ResetSpawning()
    {
        waveIndex = -1;
        Data.doneSpawning = false;
        zombiesFromWave = 0;
        currentPoint = null;
        nextSpawn = 0f;
    }

    void SpawnNewZombie() {
        int zSFW = Random.Range(0, 5);
        GameObject zombieObject = Instantiate(spawningRound.waves[waveIndex].spawningObjects[zombiesFromWave].GetSpawn(), currentPoint.position, Quaternion.identity);
        zombieObject.GetComponent<Pathfinding.AIDestinationSetter>().target = Data.freezerTransform;
        Data.spawnedZombies.Add(zombieObject);
        NewZombieSFW(zSFW);
    }

    void NewZombieSFW(int zSFW)
    {
        if (zSFW == 0)
        {
            zombieSpawnSFX_1.Play();
        }
        else if (zSFW == 1)
        {
            zombieSpawnSFX_2.Play();
        }
        else if (zSFW == 2)
        {
            zombieSpawnSFX_3.Play();
        }
        else if (zSFW == 3)
        {
            zombieSpawnSFX_4.Play();
        }
        else
        {
            zombieSpawnSFX_5.Play();
        }
    }
}