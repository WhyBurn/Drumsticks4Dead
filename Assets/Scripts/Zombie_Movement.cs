using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pathfinder))]
public class Zombie_Movement : CharacterController
{
    [SerializeField]
    public float speed = 12.0f;
    [SerializeField] private GameObject TestFreezer;

    public Transform target;
    public float recalculatePathTime;
    private float count;
    private List<Vector2> path;
    private Vector2 previousPosition;

    // Start is called before the first frame update
    public override void OnStart()
    {
        path = new List<Vector2>();
         target = TestFreezer.transform;
    }

    // Update is called once per frame
    public override Vector2 GetMovement()
    {
        if(path.Count <= 0)
        {
            return (new Vector2(0, 0));
        }
        // float step = speed * Time.deltaTime;
        //  transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        return (new Vector3(path[0].x, path[0].y) - transform.position).normalized;
    }

    public override void TryAction()
    {
        count += Time.deltaTime;
        if(count > recalculatePathTime)
        {
            count -= recalculatePathTime;
            path = GetComponent<Pathfinder>().GetPath(new int[] { 13 });
        }
        if (path.Count > 0)
        {
            if (((previousPosition.x <= path[0].x && transform.position.x >= path[0].x) || (previousPosition.x >= path[0].x && transform.position.x <= path[0].x))
                && ((previousPosition.y <= path[0].y && transform.position.y >= path[0].y) || (previousPosition.y >= path[0].y && transform.position.y <= path[0].y)))
            {
                path.RemoveAt(0);
            }
        }
        previousPosition = transform.position;
    }
}
