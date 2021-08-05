using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy
{
    // Start is called before the first frame update
    public float speed;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Fire(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Fire(Quaternion rotation)
    {
        transform.rotation = rotation;

        //Debug.Log(" bullets rotation: " + transform.eulerAngles.z + " pos: " + transform.position);

        //Time.timeScale = 0;

        Vector2 vel = transform.rotation * Vector2.right;

        gameObject.GetComponent<Rigidbody2D>().velocity = vel * speed;

        
    }
}
