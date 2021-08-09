using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallBoss : MonoBehaviour
{

    Coroutine runRoutine;
    public float launchForce;
    public float loadTime;
    public float vulnerableTime;
    public float launchTime;
    public float decelerationTime;
    
    BossDoors bossDoors;
    Rigidbody2D rb;

    string startingTag;
    public Color vulColor;
    Color startingColor;
    public Color rechargeColor;
    Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        //bossDoors = GetComponent<Boss>().doors;
        //target = GameManager.instance.playerReference.transform;
        rb = GetComponent<Rigidbody2D>();
        startingTag = gameObject.tag;
        startingColor = GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update()
    {
       // if (runRoutine == null && GameManager.instance.playerReference != null)
       // {//
        //    runRoutine = StartCoroutine(RunRoutine(GameManager.instance.playerReference.transform));
        //}

        //rotate
        rb.angularVelocity = 0;
        transform.Rotate(0,0,180f * Time.deltaTime);
    }
    
    IEnumerator RunRoutine(Transform player)
    {
        target = player;
        while (true)
        {
            Reset();
            yield return new WaitForSeconds(loadTime);
            //launch towards player
            rb.AddForce(CalculateLaunchVector(), ForceMode2D.Impulse);
            yield return new WaitForSeconds(launchTime);
            //slow down and become vulnerable
            StartCoroutine(Slow());
            yield return new WaitForSeconds(vulnerableTime);
            Reset();
            //to show vulnerability change color to blue
            //reset (change color to white and make invincible) and get ready to launch at player.
            //yield return new WaitForSeconds(loadTime);

            //yield return null;
        }
    }



    public void StartRoutine(Transform player)
    {
        if (runRoutine == null)
        {
            runRoutine = StartCoroutine(RunRoutine(player));
        }
    }

    public Vector2 CalculateLaunchVector()
    {

        Vector2 diff = target.position - transform.position;
        diff.Normalize();
        diff *= launchForce;

        return diff;
    }

    public IEnumerator Slow()
    {
        //lerp position to 0
        Vector3 startingVel = rb.velocity;
        //float startingTime = Time.time;

        float timer = 1;

        GetComponent<Boss>().playerKills = true;
        gameObject.tag = "Untagged";
        GetComponent<SpriteRenderer>().color = vulColor;


        while (timer >= 0)
        {
            rb.velocity = Vector3.Lerp(startingVel, Vector3.zero, 1f - timer);
            timer -= Time.deltaTime / decelerationTime;
            yield return null;
        }
        //GetComponent<Boss>().playerKills = true;

        //Debug.Log("Slow time: " + (Time.time - startingTime));

        

        GetComponent<SpriteRenderer>().color = rechargeColor;


    }

    public void Reset()
    {
        GetComponent<Boss>().playerKills = false;
        gameObject.tag = startingTag;
        GetComponent<SpriteRenderer>().color = startingColor;
    }
}
