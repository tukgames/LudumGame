using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public bool playerKills;
    public bool wallKills;

    public int spawnProbability;
    public int hitpoints;

    [HideInInspector]
    public int startingHitPoints;

    public int scoreValue;

    //public int distanceToDestroy = 100;

    public GameObject particlePrefab;

    // Update is called once per frame
    void Update()
    {
        /*Vector3 diff = transform.position - GameManager.instance.playerReference.transform.position;

        if(Math.Abs(diff.x) + Math.Abs(diff.y) > distanceToDestroy)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("wall") && wallKills)
        {
            if (!StateManager.instance.playerDead)
            {
                if (particlePrefab != null)
                {
                    Instantiate(particlePrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
        else if (collision.transform.CompareTag("Player") && playerKills)
        {
            hitpoints -= collision.gameObject.GetComponent<Player>().damage;
            DecreaseHealthBar();
            if (hitpoints <= 0)
            {
                if (particlePrefab != null)
                {
                    Instantiate(particlePrefab, transform.position, Quaternion.identity);
                }
                PlayerKilled();
                DestroyHealthBar();
                OpenDoors();
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(enemyFlickerCharacter());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if(collision.transform.name == "blankLeave")
        {
            DestroyHealthBar();
            Destroy(gameObject);
        }*/
        

    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "tileLeave")
        {
            Destroy(gameObject);
        }
    }*/

    public virtual IEnumerator enemyFlickerCharacter()
    {
        if (transform.GetComponent<SpriteRenderer>() != null)
        {
            Color tmp = transform.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.30f;
            transform.GetComponent<SpriteRenderer>().color = tmp;

            yield return new WaitForSeconds(0.1f);

            tmp = transform.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            transform.GetComponent<SpriteRenderer>().color = tmp;
        }

    }

    public virtual void DecreaseHealthBar()
    {

    }

    public virtual void DestroyHealthBar()
    {

    }

    public virtual void OpenDoors()
    {

    }

    public void DestroyEnemy()
    {
        DestroyHealthBar();
        Destroy(gameObject);
    }

    public void PlayerKilled()
    {
        ScoreManager.instance.EnemyKilled(scoreValue);
    }

    


}
