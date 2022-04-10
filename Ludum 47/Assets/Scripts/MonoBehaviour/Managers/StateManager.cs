using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gamePaused;
    public bool playerDead;

    public GameObject deathPanel;
    




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
        gamePaused = false;
        playerDead = false;
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
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }
    }


}
