using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gamePaused;
    public bool playerDead;

    [HideInInspector]public GameObject deathPanel;
    




    public static StateManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        Reset();
    }


    public void Pause()
    {
        gamePaused = true;
        playerDead = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        gamePaused = false;
        playerDead = false;
        Time.timeScale = 1;
    }

    public void PlayerDied()
    {
        playerDead = true;
        gamePaused = false;
        Time.timeScale = 1;
        //ScoreManager.instance.ResetScoreManager();
        //CoinManager.instance.ResetCoins();
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }
    }

    public void Reset()
    {
        gamePaused = false;
        playerDead = false;
    }


}
