using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeldItem : MonoBehaviour
{
    private bool held;
    public GameObject fryedVersion;
    public float fryTime;
    public int itemId;
    private bool thrown;
    public int[] combinationObjects;
    public GameObject[] combinationResults;

    private Dictionary<int, GameObject> objectCombinations;

    public bool Held
    {
        get { return (held); }
        set { held = value; }
    }

    public bool Thrown
    {
        get { return (thrown); }
        set { thrown = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeCombinations();
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeCombinations()
    {
        objectCombinations = new Dictionary<int, GameObject>();
        for (int i = 0; i < Mathf.Min(combinationObjects.Length, combinationResults.Length); ++i)
        {
            objectCombinations.Add(combinationObjects[i], combinationResults[i]);
        }
    }

    public abstract void OnStart();

    public abstract HeldItem Throw();

    public GameObject GetCombinationObject(int objId)
    {
        if(objectCombinations == null)
        {
            MakeCombinations();
        }
        if(objectCombinations.TryGetValue(objId, out GameObject result))
        {
            return (result);
        }
        return (null);
    }
}
