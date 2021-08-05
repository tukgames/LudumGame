using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{

    public float wanderSpeed;

    public float intervalChangeTime;

    

    Rigidbody2D rb2d;

    Vector2 vel;


    public Coroutine wanderCoroutine;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        wanderCoroutine = StartCoroutine(WanderCoroutine());
    }

    private void Update()
    {
        
    }

    public IEnumerator WanderCoroutine()
    {
        while (true)
        {
            CalculateVelocity();

            yield return new WaitForSeconds(intervalChangeTime);
        }
    }


    void CalculateVelocity()
    {
         float velX = UnityEngine.Random.Range(0.0f, 1.0f);
         float velY = 1f - velX;

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 1:
                velX = -velX;
                break;

            case 2:
                velX = -velX;
                velY = -velY;
                break;

            case 0:
                velY = -velY;
                break;

            case 3:
                break;

            default:
                Debug.Log("There was a was an error calculating vel.");
                break;

        }


        vel = new Vector2(velX, velY);
        vel.Normalize();
        vel *= wanderSpeed;


        rb2d.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Detected collision for instant enemy");
        if (vel != null)
        {
            rb2d.velocity = -vel;
        }
    }


    public void StopWander()
    {
        StopCoroutine(wanderCoroutine);
       // wanderCoroutine = null;
    }

    public void StartWander()
    {
        if (wanderCoroutine != null)
        {
            wanderCoroutine = StartCoroutine(WanderCoroutine());
        }
    }

}
