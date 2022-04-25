using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public float stepSize;
    public float checkRadius;
    public bool[] canMove;

    public List<Vector2> GetPath(int[] possibleTargets)
    {
        if(possibleTargets.Length <= 0)
        {
            return (new List<Vector2>());
        }
        PriorityQueue<PathNode> possibleMoves = new PriorityQueue<PathNode>();
        List<Vector2> movedSpaces = new List<Vector2>();
        possibleMoves.Add(new PathNode(transform.position, 0));
        float diagonalDistance = Mathf.Sqrt(2 * stepSize * stepSize);
        while(possibleMoves.Size() > 0)
        {
            PathNode currentNode = possibleMoves.Remove();
            bool notVisitied = true;
            for(int i = 0; i < movedSpaces.Count; ++i)
            {
                if(Mathf.Abs(movedSpaces[i].x - currentNode.Position.x) <= stepSize / 100 && Mathf.Abs(movedSpaces[i].y - currentNode.Position.y) <= stepSize / 100f )
                {
                    notVisitied = false;
                    break;
                }
            }
            if (notVisitied)
            {
                movedSpaces.Add(currentNode.Position);
                Collider2D[] nearby = Physics2D.OverlapCircleAll(currentNode.Position, checkRadius);
                bool blocked = false;
                for (int i = 0; i < nearby.Length; ++i)
                {
                    if (nearby[i].gameObject != gameObject)
                    {
                        int collisionLayer = nearby[i].gameObject.layer;
                        for (int p = 0; p < possibleTargets.Length; ++p)
                        {
                            if (possibleTargets[p] == collisionLayer)
                            {
                                return (currentNode.BuildPath());
                            }
                        }
                        if(!canMove[collisionLayer])
                        {
                            blocked = true;
                        }
                    }
                }
                if(!blocked)
                {
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(stepSize, 0), currentNode.Distance + stepSize, currentNode));
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(-1 * stepSize, 0), currentNode.Distance + stepSize, currentNode));
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(0, stepSize), currentNode.Distance + stepSize, currentNode));
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(0, -1 * stepSize), currentNode.Distance + stepSize, currentNode));

                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(stepSize, stepSize), currentNode.Distance + diagonalDistance, currentNode));
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(stepSize, -1 * stepSize), currentNode.Distance + diagonalDistance, currentNode));
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(-1 * stepSize, stepSize), currentNode.Distance + diagonalDistance, currentNode));
                    possibleMoves.Add(new PathNode(currentNode.Position + new Vector2(-1 * stepSize, -1 * stepSize), currentNode.Distance + diagonalDistance, currentNode));
                }
            }
        }
        return (new List<Vector2>());
    }
}
