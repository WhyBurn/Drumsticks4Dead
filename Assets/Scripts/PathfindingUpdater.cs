using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingUpdater : MonoBehaviour
{
    public float tickTime;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= tickTime)
        {
            count = 0;
            AstarPath.active.UpdateGraphs(new Bounds(new Vector3(0, 0), new Vector3(364, 206)));
        }
    }
}
