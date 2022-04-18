using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public static TileGenerator instance;

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

    public List<GameObject> allPossibleTiles;

    public List<GameObject> currentTiles;

    public List<GameObject> currentBlankTiles;

    public GameObject blankPrefab;

    public float tileWidth;
    public float disToSpawnFinalPortal;
    void Start()
    {
       /*for(int i = -5; i <= 5; i++)
        {
            for (int t = -5; t <= 5; t++) { 
                //if(getTile(i,t) == null)
                //{
                    SpawnTile(i, t);
                //Debug.Log("Tile Spawned");
                //}
            }
                
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getTile(int x, int y)
    {
            foreach (GameObject tile in currentTiles)
            {
                if (tile.GetComponent<Tile>().xValue == x && tile.GetComponent<Tile>().yValue == y)
                {
                //Debug.Log("Found tile");
                    return tile;
                }
            }
        

        return null;
    }

    public GameObject getBlankTile(int x, int y)
    {
        foreach (GameObject tile in currentBlankTiles)
        {
            if (tile.GetComponent<BlankTile>().xValue == x && tile.GetComponent<BlankTile>().yValue == y)
            {
                //Debug.Log("Found blank tile");
                return tile;
            }
        }


        return null;
    }

    /*
     x and y is the coordinates of a tile. More tiles will be spawned around this tile based on availibility.
     */
    public void SpawnTile(int x, int y)
    {
        List<GameObject> possibleTiles;
        possibleTiles = new List<GameObject>();

        foreach(GameObject tile in allPossibleTiles)
        {
            possibleTiles.Add(tile);
        }

        int timeToLoop = possibleTiles.Count;
        int amountRemoved = 0;

        //Debug.Log(possibleTiles.Count);

        if (getTile(x, y - 1) != null)
        {
            if (getTile(x, y - 1).GetComponent<Tile>().up)
            {
                for(int i = 0; i < timeToLoop; i++)
                {

                    //Debug.Log("" + i);
                    if (!possibleTiles[i-amountRemoved].GetComponent<Tile>().down)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                        if(i - amountRemoved < 0)
                        {
                            Debug.Log(" i = " + i + " amount equals " + amountRemoved);
                            Debug.Log("Error");
                        }
                        //Debug.Log("Removed Something");
                    }
                }
            }else {
                for(int i = 0; i < timeToLoop; i++)
                {
                    //Debug.Log("" + i);
                    if (possibleTiles[i-amountRemoved].GetComponent<Tile>().down)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;

                        //Debug.Log("Removed Something");
                        if (i - amountRemoved < 0)
                        {
                            //Debug.Log(" i = " + i + " amount equals " + amountRemoved);
                           // Debug.Log("Error");
                        }



                    }
                }
            }
        }

        timeToLoop = possibleTiles.Count;
        amountRemoved = 0;


        if (getTile(x, y + 1) != null)
        {
            if (getTile(x, y + 1).GetComponent<Tile>().down)
            {
                for(int i = 0; i < timeToLoop; i++)
                {
                    if (!possibleTiles[i-amountRemoved].GetComponent<Tile>().up)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                    }
                }
            }
            else
            {
                for(int i = 0; i < timeToLoop; i++)
                {
                    if (possibleTiles[i-amountRemoved].GetComponent<Tile>().up)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                    }
                }
            }
        }

        timeToLoop = possibleTiles.Count;
        amountRemoved = 0;

        if (getTile(x-1,y) != null)
        {
            if (getTile(x-1, y).GetComponent<Tile>().right)
            {
                for(int i = 0; i < timeToLoop; i++)
                {
                    //Debug.Log("Does loop through");
                    if (!possibleTiles[i-amountRemoved].GetComponent<Tile>().left)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                    }
                }
            }
            else
            {
                for(int i = 0; i < timeToLoop; i++)
                {
                    if (possibleTiles[i-amountRemoved].GetComponent<Tile>().left)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                    }
                }
            }
        }

        timeToLoop = possibleTiles.Count;
        amountRemoved = 0;

        if (getTile(x + 1, y) != null)
        {
            if (getTile(x + 1, y).GetComponent<Tile>().left)
            {
                for(int i = 0; i < timeToLoop; i++)
                {
                    //Debug.Log("Does loop through");
                    if (!possibleTiles[i-amountRemoved].GetComponent<Tile>().right)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                    }
                }
            }
            else
            {
                for(int i = 0; i < timeToLoop; i++)
                {
                    if (possibleTiles[i-amountRemoved].GetComponent<Tile>().right)
                    {
                        possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                        amountRemoved++;
                    }
                }
            }


        }

        timeToLoop = possibleTiles.Count;
        amountRemoved = 0;

        if (BossManager.instance.alreadyBoss)
        {
            for (int i = 0; i < timeToLoop; i++)
            {
                //Debug.Log("Does loop through");
                if (possibleTiles[i - amountRemoved].GetComponent<Tile>().isBoss)
                {
                    possibleTiles.Remove(possibleTiles[i - amountRemoved]);
                    amountRemoved++;
                }
            }
        }

        if(disToSpawnFinalPortal > Mathf.Abs(x) + Mathf.Abs(y))
        {
            for(int i = possibleTiles.Count-1; i >= 0; i--)
            {
                if (possibleTiles[i].GetComponent<Tile>().isPortal)
                {

                    Debug.Log("Removed " + possibleTiles[i].name);
                    possibleTiles.Remove(possibleTiles[i]);
                }
            }
        }



        //int val = Random.Range(0,possibleTiles.Count);

        //Debug.Log("Count after " + possibleTiles.Count + "Random Generated = " + val);

        //if(possibleTiles[val] != null)
        //{
        GameObject toSpawn = getTileToSpawn(possibleTiles);

        

        if (toSpawn != null)
        {

            if (toSpawn.GetComponent<Tile>().isBoss)
            {
                BossManager.instance.alreadyBoss = true;
            }

            GameObject til = SpawnTile(toSpawn,x,y);

            if (til.GetComponent<Tile>().spawnsEnemies)
            {
                EnemySpawner.instance.SpawnEnemies(x, y, tileWidth);
            }
        }
        //}
    }

    public GameObject getTileToSpawn(List<GameObject> tiles)
    {
        //Debug.Log(tiles.ToString());
        int totalPriority = 0;

        foreach(GameObject tile in tiles)
        {
            totalPriority += tile.GetComponent<Tile>().priority;
        }

        int rand = Random.Range(0, totalPriority) + 1;

        int addedSoFar = 0;

        foreach(GameObject tile in tiles)
        {
            if(tile.GetComponent<Tile>().priority + addedSoFar >= rand)
            {
                return tile;
            }
            else
            {
                addedSoFar += tile.GetComponent<Tile>().priority;
            }
        }

        return null;
    }

    public void spawnSurroundingBlanks(int x, int y)
    {
        if(getBlankTile(x-1,y) == null && getTile(x-1, y) == null)
        {
            //spawn blank
            SpawnBlank(x-1, y);
        }

        if (getBlankTile(x + 1, y) == null && getTile(x + 1, y) == null)
        {
            //spawn blank
            SpawnBlank(x + 1, y);
        }

        if (getBlankTile(x, y+1) == null && getTile(x, y+1) == null)
        {
            //spawn blank
            SpawnBlank(x, y + 1);
        }

        if (getBlankTile(x, y - 1) == null && getTile(x, y - 1) == null)
        {
            //spawn blank
            SpawnBlank(x, y - 1);
        }


    }

    public void SpawnBlank(int x, int y)
    {
        GameObject blank = Instantiate(blankPrefab, new Vector3((float)x * tileWidth, (float)y * tileWidth, 0), Quaternion.identity);

        blank.GetComponent<BlankTile>().xValue = x;
        blank.GetComponent<BlankTile>().yValue = y;

        blank.transform.localScale = new Vector3(tileWidth, tileWidth, 1f);

        currentBlankTiles.Add(blank);
    }

     //reset Tile Generator Class
     public void Reset()
    {
        currentBlankTiles.Clear();
        currentTiles.Clear();
    }


    public GameObject SpawnTile(GameObject toSpawn, int x, int y)
    {
        GameObject til = Instantiate(toSpawn, new Vector3((float)x * tileWidth, (float)y * tileWidth, 0), Quaternion.identity);
        til.transform.localScale = new Vector3(tileWidth * (til.transform.localScale.x / Mathf.Abs(til.transform.localScale.x)), tileWidth * (til.transform.localScale.y / Mathf.Abs(til.transform.localScale.y)), 1f);
        til.GetComponent<Tile>().xValue = x;
        til.GetComponent<Tile>().yValue = y;
        currentTiles.Add(til);
        return til;
    }


    




    
}
