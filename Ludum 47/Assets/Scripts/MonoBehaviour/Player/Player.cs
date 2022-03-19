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
        Debug.Log(collision.transform.tag);
        if(collision.transform.CompareTag("Kill player"))
        {
            //Debug.Log("Player hit a killing object.");
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
