using System;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : IComparable<PathNode>
{
    private Vector2 position;
    private float distance;
    private PathNode previous;

    public Vector2 Position
    {
        get { return (position); }
    }

    public float Distance
    {
        get { return (distance); }
    }

    public PathNode(Vector2 p, float d) : this(p, d, null)
    {
    }

    public PathNode(Vector2 pos, float d, PathNode pre)
    {
        position = pos;
        distance = d;
        previous = pre;
    }

    public int CompareTo(PathNode other)
    {
        if(distance > other.distance)
        {
            return (1);
        }
        else if(distance < other.distance)
        {
            return (-1);
        }
        return (0);
    }

    public List<Vector2> BuildPath()
    {
        List<Vector2> path = new List<Vector2>();
        path.Add(position);
        PathNode current = previous;
        while(current != null)
        {
            path.Add(current.position);
            current = current.previous;
        }
        return (path);
    }
}
