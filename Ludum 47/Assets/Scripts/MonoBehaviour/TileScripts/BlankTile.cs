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
    }

    public void Collided()
    {
        TileGenerator.instance.currentBlankTiles.Remove(gameObject);
        TileGenerator.instance.SpawnTile(xValue, yValue);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.name == "blankLeave")
        {
            TileGenerator.instance.currentBlankTiles.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
