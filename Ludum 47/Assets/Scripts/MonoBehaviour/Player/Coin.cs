using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int value;
    public float spawnForceRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-spawnForceRange, spawnForceRange), Random.Range(-spawnForceRange, spawnForceRange)));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.name == "blankLeave")
        {
            Destroy(gameObject);
        }


    }

    public void Collect()
    {
        CoinManager.instance.AddCoin(value);
        Destroy(gameObject);
    }
}
