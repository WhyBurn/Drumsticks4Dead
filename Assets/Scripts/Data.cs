using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static bool doneSpawning;
    public static bool gameLost;
    public static bool reset;
    public static List<GameObject> spawnedZombies = new List<GameObject>();
    public static List<GameObject> spawnedItems = new List<GameObject>();
    public static List<GameObject> deletedItems = new List<GameObject>();
    public static List<GameObject> deletedZombies = new List<GameObject>();
    public static Transform freezerTransform;
    public static float spawnTime;
}
