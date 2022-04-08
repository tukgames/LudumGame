using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class panelTextUpdater : MonoBehaviour
{
    public ScoreManager sManager;
    public TextMeshProUGUI scoreText;

    public CoinManager cManager;
    public TextMeshProUGUI coinsText;


    // Start is called before the first frame update
    void Start()
    {
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
