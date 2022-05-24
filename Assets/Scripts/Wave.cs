using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Wave", order = 0)]
public class Wave : ScriptableObject
{
    public SpawnOption[] spawningObjects;
    public float spawnDelay;
}
