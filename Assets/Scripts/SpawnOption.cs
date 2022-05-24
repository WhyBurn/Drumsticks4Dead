using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnOption", menuName = "ScriptableObjects/SpawnOption", order = 2)]
public class SpawnOption : ScriptableObject
{
    public GameObject[] possibleSpawns;

    public GameObject GetSpawn()
    {
        return (possibleSpawns[Random.Range(0, possibleSpawns.Length)]);
    }
}
