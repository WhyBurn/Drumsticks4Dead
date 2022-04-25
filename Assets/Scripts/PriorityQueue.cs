using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> queue;
    private int leastIndex;
    public PriorityQueue()
    {
        queue = new List<T>();
        leastIndex = -1;
    }

    public void Add(T item)
    {
        queue.Add(item);
        if (leastIndex >= 0)
        {
            if (item.CompareTo(queue[leastIndex]) < 0)
            {
                leastIndex = queue.Count - 1;
            }
        }
        else
        {
            leastIndex = 0;
        }
    }

    public T Remove()
    {
        if (leastIndex < 0)
        {
            return (default(T));
        }
        T least = queue[leastIndex];
        queue.RemoveAt(leastIndex);
        leastIndex = 0;
        for (int i = 1; i < queue.Count; ++i)
        {
            if (queue[i].CompareTo(queue[leastIndex]) < 0)
            {
                leastIndex = i;
            }
        }
        return (least);
    }

    public T Peek()
    {
        if (leastIndex < 0)
        {
            return (default(T));
        }
        return (queue[leastIndex]);
    }

    public int Size()
    {
        return (queue.Count);
    }
}
