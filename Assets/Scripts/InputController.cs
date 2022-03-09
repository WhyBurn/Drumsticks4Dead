using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public int numPlayers;

    // Start is called before the first frame update
    void Start()
    {
        Inputs.playerInteractDown = new bool[numPlayers];
        Inputs.playerInteractHold = new bool[numPlayers];
        Inputs.playerInteractUp = new bool[numPlayers];
        Inputs.playerThrowDown = new bool[numPlayers];
        Inputs.playerThrowHold = new bool[numPlayers];
        Inputs.playerThrowUp = new bool[numPlayers];
        Inputs.playerMovements = new Vector2[numPlayers];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numPlayers; ++i)
        {
            Inputs.playerMovements[i] = new Vector2(Input.GetAxis("Horizontal" + i), Input.GetAxis("Vertical" + i)).normalized;
            Inputs.playerInteractDown[i] = !Inputs.playerInteractHold[i] && Input.GetAxis("Interact" + i) > 0;
            Inputs.playerInteractUp[i] = Inputs.playerInteractHold[i] && Input.GetAxis("Interact" + i) == 0;
            Inputs.playerInteractHold[i] = Input.GetAxis("Interact" + i) > 0;
            Inputs.playerThrowDown[i] = !Inputs.playerThrowHold[i] && Input.GetAxis("Throw" + i) > 0;
            Inputs.playerThrowUp[i] = Inputs.playerThrowHold[i] && Input.GetAxis("Throw" + i) == 0;
            Inputs.playerThrowHold[i] = Input.GetAxis("Throw" + i) > 0;
        }
    }
}
