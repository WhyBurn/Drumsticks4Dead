using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnRound", menuName = "ScriptableObjects/SpawnRound", order = 1)]
public class SpawningRound : ScriptableObject
{
    public Wave[] waves;
    public float[] waveDelays;
}
