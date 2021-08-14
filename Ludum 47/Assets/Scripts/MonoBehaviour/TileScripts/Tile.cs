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

    public bool spawnsEnemies;

    public List<GameObject> currentEnemies;
    void Start()
    {
        if (isStarting)
        {
            TileGenerator.instance.currentTiles.Add(gameObject);
        }

        

        TileGenerator.instance.spawnSurroundingBlanks(xValue, yValue);
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
                //Debug.Log("Tile Despawned " + xValue + "" + yValue);
                DestroyEnemies();
                //Debug.Log("Got here");
                TileGenerator.instance.SpawnBlank(xValue, yValue);
                TileGenerator.instance.currentTiles.Remove(gameObject);
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
        if(collision.GetComponent<Enemy>() != null)
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
        int amountRemoved = 0;
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
                Destroy(currentEnemies[i].gameObject);
            }
        }
    }

    

    


    
}

    