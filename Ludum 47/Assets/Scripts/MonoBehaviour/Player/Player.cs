using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject ExplosionPrefab;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Old Code before change to support children
        /*
        if(collision.transform.CompareTag("Kill player"))
        {
            //Debug.Log("Player hit a killing object.");
            KillPlayer();
        }
        */

        if(collision.GetContact(0).collider.transform.CompareTag("Kill player")) {
            KillPlayer();
        }
    }


    public void KillPlayer()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        StateManager.instance.PlayerDied();
        GetComponent<TrailParticle>().OnPlayerDeath();
        GetComponent<DragBack>().OnPlayerDeath();
        Destroy(gameObject);
    }
}
