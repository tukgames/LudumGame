using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCoinDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Text coinText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + ScoreManager.instance.score;
        coinText.text = "Coins: " + CoinManager.instance.coinsThisRound;
    }
}
