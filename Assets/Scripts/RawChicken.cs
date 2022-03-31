using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawChicken : HeldItem
{
    public override void OnStart()
    {
        
    }

    public override HeldItem Throw()
    {
        return (this);
    }
}
