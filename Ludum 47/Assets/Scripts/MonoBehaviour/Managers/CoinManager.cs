using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public GameObject bronzeCoinPrefab;

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
    }
    // Start is called before the first frame update
    float totalCoins  =  0;
    float coinsThisRound = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(float c)
    {
        float a = 0;
        if(ScoreManager.instance.multiplier > 0)
        {
            a = c * ScoreManager.instance.multiplier;
        } else
        {
            a = c;
        }
        coinsThisRound += a;
        totalCoins += a;


        Debug.Log("Coins: " + coinsThisRound);
    }

    public void restartGame()
    {
        coinsThisRound = 0;
    }


    public void SpawnCoin(Vector3 location)
    {
        Coin coin = Instantiate(bronzeCoinPrefab, location, Quaternion.identity).GetComponent<Coin>();
        coin.spawn();
    }
}
