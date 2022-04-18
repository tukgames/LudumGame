using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update

    public bool up, down, left, right;

    public int xValue;
    public int yValue;

    public int priority;

    public bool isStarting;
    public bool isBoss;
    public bool isPortal;

    public bool spawnsEnemies;

    public List<GameObject> currentEnemies;
    void Start()
    {
        /*if (isStarting)
        {
            TileGenerator.instance.currentTiles.Add(gameObject);
        }*/



        TileGenerator.instance.spawnSurroundingBlanks(xValue, yValue);
        //Debug.Log("Spawned Surrounding Blanks");
        //List<GameObject> collidingEnemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            if (collision.transform.name == "tileLeave" && !StateManager.instance.playerDead)
            {
                //Debug.Log("tile despawned" + transform.name);
                //Debug.Log("Tile Despawned " + xValue + "" + yValue + " " + transform.name);
                if (collision.transform.name.Contains("oss"))
                {
                    Debug.Log(collision.name);
                }
                DestroyEnemies();
                //Debug.Log("Got here");
                TileGenerator.instance.SpawnBlank(xValue, yValue);
                TileGenerator.instance.currentTiles.Remove(gameObject);
                if (isPortal)
                {
                    BossManager.instance.alreadyBoss = false;
                }
                //Debug.Log("Got here 2");
                Destroy(gameObject);
            }

            if (collision.GetComponent<Enemy>() != null)
            {
                //add enemy to list
                //delete enemy from list

                if (currentEnemies.Contains(collision.gameObject))
                {
                    currentEnemies.Remove(collision.gameObject);
                }

            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            //add enemy to list
            if (!currentEnemies.Contains(collision.gameObject))
            {
                currentEnemies.Add(collision.gameObject);
            }

        }
    }

    public void DestroyEnemies()
    {
        int numEnemies = currentEnemies.Count;
        //int amountRemoved = 0;
        /*for(int i = 0; i < numEnemies; i++)
        {
            if (currentEnemies[i-amountRemoved] != null)
            {

                //Debug.Log(currentEnemies[0].transform.position);
                Debug.Log("step zero");

                GameObject enemyToDestroy = currentEnemies[i-amountRemoved];
                Debug.Log("step one");
                currentEnemies.Remove(currentEnemies[0]);
                Debug.Log("step two");
                Destroy(enemyToDestroy);
                Debug.Log("step three");
                amountRemoved++;
            }
            Debug.Log("step four");
        }*/

        for (int i = currentEnemies.Count - 1; i >= 0; i--)
        {
            if (currentEnemies[i] != null)
            {
                if (currentEnemies[i].name.Contains("oss"))
                {
                    Debug.Log(currentEnemies[i].name);
                }
                Destroy(currentEnemies[i].gameObject);
            }
        }
    }


    void OnDestroy()
    {
        if(isPortal){
            BossManager.instance.alreadyBoss = false;
        }
    }
    


    
}

    