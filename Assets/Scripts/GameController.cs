using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerPrefab;
    public GameObject[] playerSpawnLocations;
    public float tickTime;
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
        Data.gameController = this;
        count = 0;
        losingGame = false;
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.gameLost)
        {
            if(losingGame)
            {
                count += Time.deltaTime;
                if(count >= loseTime)
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
            count += Time.deltaTime;
            if (count >= tickTime)
            {
                count -= tickTime;
                for (int i = 0; i < spawnedItems.Count; ++i)
                {
                    if (spawnedItems[i] == null)
                    {
                        spawnedItems.RemoveAt(i);
                        --i;
                    }
                }
                for (int i = 0; i < spawnedZombies.Count; ++i)
                {
                    if (spawnedZombies[i] == null)
                    {
                        spawnedZombies.RemoveAt(i);
                        --i;
                    }
                }
                if (Data.doneSpawning && spawnedZombies.Count <= 0)
                {
                    WinGame();
                }
            }
        }
    }

    public void SetUp(int numPlayers)
    {
        ClearObjects();
        players = new GameObject[numPlayers];
        for(int i = 0; i < numPlayers; ++i)
        {
            GameObject player = Instantiate(playerPrefab.gameObject);
            player.transform.position = playerSpawnLocations[i].transform.position;
            player.GetComponent<PlayerController>().playerNumber = i;
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
            spawnedItems = new List<GameObject>();
        }
    }

    private void ClearZombies()
    {
        for (int i = 0; i < spawnedZombies.Count; ++i)
        {
            if (spawnedZombies[i] != null)
            {
                GameObject.Destroy(spawnedZombies[i].gameObject);
            }
            spawnedZombies = new List<GameObject>();
        }
    }

    public void SpawnItem(GameObject o)
    {
        spawnedItems.Add(o);
    }

    public void SpawnZombie(GameObject zombie)
    {
        spawnedZombies.Add(zombie);
    }

    public void WinGame()
    {
        Debug.Log("Winning!");
    }
}
