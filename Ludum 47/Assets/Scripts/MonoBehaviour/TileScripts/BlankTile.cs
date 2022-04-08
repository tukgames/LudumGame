using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankTile : MonoBehaviour
{
    // Start is called before the first frame update

    public int xValue;
    public int yValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "tileLeave")
        {
            Collided();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Collided();
        }
        if (collision.transform.GetComponent<Enemy>() != null)
        {
            //check the surrounding tiles.
            //bool isIn = false;
            /*if(TileGenerator.instance.getTile(xValue + 1, yValue) != null)
            {
                if(TileGenerator.instance.getTile(xValue + 1, yValue).GetComponent<Tile>().currentEnemies.Contains(collision.gameObject))
                {
                    isIn = true;
                }
            }
            if (TileGenerator.instance.getTile(xValue - 1, yValue) != null)
            {
                if (TileGenerator.instance.getTile(xValue - 1, yValue).GetComponent<Tile>().currentEnemies.Contains(collision.gameObject))
                {
                    isIn = true;
                }
            }

            if (TileGenerator.instance.getTile(xValue, yValue + 1) != null)
            {
                if (TileGenerator.instance.getTile(xValue, yValue + 1).GetComponent<Tile>().currentEnemies.Contains(collision.gameObject))
                {
                    isIn = true;
                }
            }
            if (TileGenerator.instance.getTile(xValue, yValue - 1) != null)
            {
                if (TileGenerator.instance.getTile(xValue, yValue - 1).GetComponent<Tile>().currentEnemies.Contains(collision.gameObject))
                {
                    isIn = true;
                }
            }*/

            if (!collision.isTrigger)
            {
                collision.GetComponent<Enemy>().DestroyEnemy();
               // Debug.Log("Killed enemy");
            }
        } else if(collision.transform.parent.transform.GetComponent<Enemy>() != null)
        {
            if (!collision.isTrigger)
            {
                collision.transform.parent.transform.GetComponent<Enemy>().DestroyEnemy();
                // Debug.Log("Killed enemy");
            }
        }

    }

    public void Collided()
    {
        //Debug.Log("collided " + xValue + "" + yValue);
        TileGenerator.instance.currentBlankTiles.Remove(gameObject);
        TileGenerator.instance.SpawnTile(xValue, yValue);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.name == "blankLeave")
        {
            //Debug.Log("blank tile despawned");
            TileGenerator.instance.currentBlankTiles.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
