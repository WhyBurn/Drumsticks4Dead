using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnRound", menuName = "ScriptableObjects/SpawnRound", order = 1)]
public class SpawningRound : ScriptableObject
{
    public Wave[] waves;
    public float[] waveDelays;

    public float CalculateSpawnTime()
    {
        float time = 0;
        for(int i = 0; i < waves.Length; ++i)
        {
            time += waveDelays[i];
            time += waves[i].spawnDelay * (waves[i].spawningObjects.Length);
        }
        return (time);
    }
}
