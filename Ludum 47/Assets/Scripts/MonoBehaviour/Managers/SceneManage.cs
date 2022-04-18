using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public static SceneManage instance;

    public string baseScene;

    void Awake()
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
    void Start()
    {
        //Restart();   
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        TileGenerator.instance.Reset();
        SceneManager.LoadScene(name);
        

        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("EndlessMode") && GameManager.instance.playerReference == null)
        {
            //Debug.Log(Time.timeSinceLevelLoad);
            InitialTileManager.instance.SpawnInitialTile();
        }
    }

    public void Restart()
    {
        //TileGenerator.instance.Reset();
        ScoreManager.instance.ResetScoreManager();
        CoinManager.instance.ResetCoins();
        InitialTileManager.instance.Reset();
        StateManager.instance.Reset();
        LoadScene(baseScene);
        
    }
}
