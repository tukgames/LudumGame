using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public Spawner playerSpawner;

    public static GameManager instance;

    public GameObject playerReference;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);

        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnLoad()
    {
        //SpawnPlayer();
    }

    void Start()
    {
        //SpawnPlayer();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void SpawnPlayer(Spawner playerSpawner)
    {
        playerReference = playerSpawner.spawnObject();

        if (CoinManager.instance != null)
        {
            CoinManager.instance.ResetCoins();
        }

        Camera.main.GetComponent<CameraFollow>().target = playerReference.transform;

        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name == "axis")
            {
                gameObj.GetComponent<MissleRotate>().target = playerReference.transform;
            }
        }
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name == "spawn point turret")
            {
                gameObj.GetComponent<TurretFire>().target = playerReference.transform;
            }
        }
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name.Contains("Rail Gun Enemy"))
            {
                gameObj.GetComponent<RailGunEnemy>().target = playerReference.transform;
            }
        }
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name.Contains("MissleProj"))
            {
                gameObj.GetComponent<MissleFollow>().target = playerReference.transform;
            }
        }
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name.Contains("Dash Enemy"))
            {
                gameObj.GetComponent<DashEnemy>().target = playerReference.transform;
            }
        }
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name.Contains("Machine Gun Enemy"))
            {
                gameObj.GetComponent<MachineGunEnemy>().target = playerReference.transform;
            }
        }


    }
}
