using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerPrefab;
    public GameObject[] playerSpawnLocations;
    public float loseTime;
    public GameObject losePanel;

    private float count;
    private GameObject[] players;
    private List<GameObject> spawnedItems;
    private List<GameObject> spawnedZombies;
    private bool losingGame;

    // Start is called before the first frame update
    void Start()
    {
        players = new GameObject[0];
        spawnedItems = new List<GameObject>();
        spawnedZombies = new List<GameObject>();
        SetUp(2);
        count = 0;
        losingGame = false;
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.gameLost)
        {
            if (losingGame)
            {
                count += Time.deltaTime;
                if (count >= loseTime)
                {
                    count = 0;
                    losePanel.SetActive(false);
                    losingGame = false;
                    Data.gameLost = false;
                    Data.doneSpawning = false;
                    SetUp(2);
                }
            }
            else
            {
                count = 0;
                losePanel.SetActive(true);
                losingGame = true;
            }
        }
        else
        {
            while (Data.spawnedItems.Count > 0)
            {
                spawnedItems.Add(Data.spawnedItems[0]);
                Data.spawnedItems.RemoveAt(0);
            }
            while (Data.spawnedZombies.Count > 0)
            {
                spawnedZombies.Add(Data.spawnedZombies[0]);
                Data.spawnedZombies.RemoveAt(0);
            }
            while(Data.deletedItems.Count >0)
            {
                spawnedItems.Remove(Data.deletedItems[0]);
                Destroy(Data.deletedItems[0]);
                Data.deletedItems.RemoveAt(0);
            }
            while (Data.deletedZombies.Count > 0)
            {
                spawnedZombies.Remove(Data.deletedZombies[0]);
                Destroy(Data.deletedZombies[0]);
                Data.deletedZombies.RemoveAt(0);
            }
            if (Data.doneSpawning && spawnedZombies.Count <= 0)
            {
                WinGame();
            }
        }
    }

    public void SetUp(int numPlayers)
    {
        ClearObjects();
        Data.spawnedZombies = new List<GameObject>();
        Data.spawnedItems = new List<GameObject>();
        Data.deletedZombies = new List<GameObject>();
        Data.deletedItems = new List<GameObject>();
        Data.doneSpawning = false;
        Data.gameLost = false;
        players = new GameObject[numPlayers];
        for(int i = 0; i < numPlayers; ++i)
        {
            GameObject player = Instantiate(playerPrefab.gameObject);
            player.transform.position = playerSpawnLocations[i].transform.position;
            player.GetComponent<PlayerController>().playerNumber = i;
            players[i] = player;
        }
    }

    public void ClearObjects()
    {
        ClearPlayers();
        ClearItems();
        ClearZombies();
    }

    private void ClearPlayers()
    {
        for(int i = 0; i < players.Length; ++i)
        {
            GameObject.Destroy(players[i].gameObject);
        }
        players = new GameObject[0];
    }

    private void ClearItems()
    {
        for(int i = 0; i < spawnedItems.Count; ++i)
        {
            if(spawnedItems[i] != null)
            {
                GameObject.Destroy(spawnedItems[i].gameObject);
            }
        }
        spawnedItems = new List<GameObject>();
    }

    private void ClearZombies()
    {
        for (int i = 0; i < spawnedZombies.Count; ++i)
        {
            if (spawnedZombies[i] != null)
            {
                GameObject.Destroy(spawnedZombies[i].gameObject);
            }
        }
        spawnedZombies = new List<GameObject>();
    }

    public void WinGame()
    {
        Debug.Log("Winning!");
    }
}
