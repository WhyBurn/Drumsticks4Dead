using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerPrefab;
    public GameObject[] playerSpawnLocations;

    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = new GameObject[0];
        SetUp(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(int numPlayers)
    {
        ClearPlayers();
        players = new GameObject[numPlayers];
        for(int i = 0; i < numPlayers; ++i)
        {
            GameObject player = Instantiate(playerPrefab.gameObject);
            player.transform.position = playerSpawnLocations[i].transform.position;
            player.GetComponent<PlayerController>().playerNumber = i;
        }
    }

    public void ClearPlayers()
    {
        for(int i = 0; i < players.Length; ++i)
        {
            GameObject.Destroy(players[i].gameObject);
        }
        players = new GameObject[0];
    }
}
