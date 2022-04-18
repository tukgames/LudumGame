using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTileManager : MonoBehaviour
{
    public static InitialTileManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }
    [HideInInspector] public Vector2 coords;

    public GameObject InitialTile;
    public GameObject AfterBossTile;

    public GameObject playerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        SpawnInitialTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        coords = Vector2.zero;
    }

    public void SpawnInitialTile()
    {
        if (coords == Vector2.zero)
        {
            GameObject temp = TileGenerator.instance.SpawnTile(InitialTile, 0, 0);
            temp.GetComponent<Tile>().spawnsEnemies = false;
            Instantiate(playerSpawner, Vector3.zero, Quaternion.identity);
        } else
        {
            //figure out how to move the player spwaner
            GameObject temp = TileGenerator.instance.SpawnTile(AfterBossTile, (int)coords.x, (int)coords.y);
            temp.GetComponent<Tile>().spawnsEnemies = false;
            Instantiate(playerSpawner, new Vector3(coords.x * TileGenerator.instance.tileWidth, coords.y * TileGenerator.instance.tileWidth, 0), Quaternion.identity);
            Camera.main.transform.position = new Vector3(coords.x * TileGenerator.instance.tileWidth, coords.y * TileGenerator.instance.tileWidth, Camera.main.transform.position.z);
        }
    }

    

}
