using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TestInteractable : Interactable
{
    private SpriteRenderer interactableRenderer;
    private float time;

    public override void OnStart()
    {
        interactableRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void OnUpdate()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                interactableRenderer.color = Color.white;
            }
        }
    }

    public override void Interact(GameObject playerObject)
    {
        Debug.Log("Interacted");
        interactableRenderer.color = new Color(1, 0, 0);
        time = 2;
    }
}
