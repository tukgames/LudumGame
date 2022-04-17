using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class panelTextUpdater : MonoBehaviour
{
    ScoreManager sManager;
    public TextMeshProUGUI scoreText;

     CoinManager cManager;
    public TextMeshProUGUI coinsText;


    // Start is called before the first frame update
    void Start()
    {
        sManager = ScoreManager.instance;
        cManager = CoinManager.instance;
        float a;
        string b;
        
        a = sManager.score;
        b = "Score: ";
        scoreText.SetText(b + a.ToString());

        a = cManager.coinsThisRound;
        b = "Coins: ";
        coinsText.SetText(b + a.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
