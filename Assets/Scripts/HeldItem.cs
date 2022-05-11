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
    public Dictionary<int, GameObject> combinationVersions;

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
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void OnStart();

    public abstract HeldItem Throw();
}
