using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public bool isPaused;

    public static UI instance;

    public GameObject DeathPanel;
    

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Pass the Death Panel to the State Manager
        StateManager.instance.deathPanel = DeathPanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Pause()
    {
        StateManager.instance.Pause();
    }

    public void Resume()
    {
        StateManager.instance.Resume();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManage.instance.Restart();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
