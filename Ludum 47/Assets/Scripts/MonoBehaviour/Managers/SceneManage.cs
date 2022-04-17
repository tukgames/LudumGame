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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);

    }


    public void Restart()
    {
        TileGenerator.instance.Reset();
        ScoreManager.instance.ResetScoreManager();
        CoinManager.instance.ResetCoins();
        LoadScene(baseScene);
    }
}
