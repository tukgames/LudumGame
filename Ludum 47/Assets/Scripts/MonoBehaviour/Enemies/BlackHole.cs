﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Enemy
{
    // Start is called before the first frame update
    //public float maxForce;
    public float affectDistance;
    //affect distance x closeMultiplier has to be less than maxForce
    //close multipler ditermines the force by closeM x affectdistance - distacnce = force
    public float closeMultiplier;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!StateManager.instance.playerDead) {
            Vector2 playerPos = GameManager.instance.playerReference.transform.position;
            float dist = Mathf.Abs(playerPos.x - transform.position.x) + Mathf.Abs(playerPos.y - transform.position.y);
            //Debug.Log(dist + "   " + affectDistance);
            if (dist < affectDistance)
            {
                
                Vector2 force = new Vector2(transform.position.x, transform.position.y) - playerPos;
                force.Normalize();
                force *= closeMultiplier * (affectDistance - dist);
                GameManager.instance.playerReference.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}
