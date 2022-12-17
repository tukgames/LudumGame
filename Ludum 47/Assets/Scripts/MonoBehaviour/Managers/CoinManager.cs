using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public GameObject bronzeCoinPrefab;
    public GameObject silverCoinPrefab;
    public GameObject goldCoinPrefab;

    public int goldSpawnPercent;
    public int silverSpawnPercent;
    public int bronzeSpawnPercent;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        ResetCoins();
    }
    // Start is called before the first frame update

    [HideInInspector] public float totalCoins;
    [HideInInspector] public float coinsThisRound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(float c)
    {
        float a = c;
        if (ScoreManager.instance != null)
        {
            if (ScoreManager.instance.multiplier > 0)
            {
                a = c * ScoreManager.instance.multiplier;
            }
        }
        coinsThisRound += a;
        totalCoins += a;


        Debug.Log("Coins: " + coinsThisRound);
    }

    /*public void restartGame()
    {
        coinsThisRound = 0;
    }*/


    public void SpawnCoin(Vector3 location)
    {
        GameObject pref = null;
        int randNum = Random.Range(1, 101);
        if(randNum <= goldSpawnPercent)
        {
            pref = goldCoinPrefab;
        } else if(randNum <= silverSpawnPercent + goldSpawnPercent)
        {
            pref = silverCoinPrefab;
        } else
        {
            pref = bronzeCoinPrefab;
        }
        Coin coin = Instantiate(pref, location, Quaternion.identity).GetComponent<Coin>();
        coin.spawn();
    }

    public void ResetCoins()
    {
        //this line is temp until save files
        //totalCoins = 0;

        coinsThisRound = 0;
    }
}
