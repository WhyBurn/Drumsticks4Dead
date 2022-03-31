using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeldItem : MonoBehaviour
{
    private bool held;
    public GameObject fryedVersion;
    public float fryTime;

    public bool Held
    {
        get { return (held); }
        set { held = value; }
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
