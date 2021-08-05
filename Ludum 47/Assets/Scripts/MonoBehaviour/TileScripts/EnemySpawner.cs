using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    //public float spawnRange;
    public List<GameObject> allEnemies;

    public int maxRequiredEnemies;
    public int randomRangeOfEnemies;

    float positionRange;

    public float spawnRate;

    GameObject enemyToSpawn;

    //public Tile tile;

    public static EnemySpawner instance;

    private void Awake()
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

    void Start()
    {
        //tile = GetComponent<Tile>();
        positionRange = TileGenerator.instance.tileWidth * 0.2f;
        
    }

    public void SpawnEnemies(int x, int y, float tileWidth)
    {
        int numRequiredEnemies = (int)((Mathf.Abs(x) + Mathf.Abs(y)) / spawnRate);

        if(numRequiredEnemies > maxRequiredEnemies)
        {
            numRequiredEnemies = maxRequiredEnemies;
        }

        int numEnemiesToSpawn = (int)(Random.Range(0, randomRangeOfEnemies + 1)) + numRequiredEnemies;

        for(int i = 0; i < numEnemiesToSpawn; i++)
        {
            SpawnRandom(x, y, tileWidth);
        }


    }

    public void SpawnRandom(int x, int y, float tileWidth)
    {
        int totalPriority = 0;

        enemyToSpawn = null;

        foreach (GameObject enemy in allEnemies)
        {
            totalPriority += enemy.GetComponent<Enemy>().spawnProbability;
        }

        int rand = Random.Range(0, totalPriority) + 1;

        int addedSoFar = 0;

        bool happend = false;

        foreach (GameObject enemy in allEnemies)
        {
            if (enemy.GetComponent<Enemy>().spawnProbability + addedSoFar >= rand)
            {
                if (!happend)
                {
                    enemyToSpawn = enemy;
                    happend = true;
                    break;
                }
                
            }
            else
            {
                addedSoFar += enemy.GetComponent<Enemy>().spawnProbability;
            }
        }

        float xPosition = Random.Range(-positionRange, positionRange);
        float yPosition = Random.Range(-positionRange, positionRange);

        if (enemyToSpawn != null)
        {
            GameObject enemy = Instantiate(enemyToSpawn, new Vector3(x * tileWidth + xPosition, y * tileWidth + yPosition, 0), Quaternion.identity);
            TileGenerator.instance.getTile(x, y).GetComponent<Tile>().currentEnemies.Add(enemy);
        }
 
    }

}
