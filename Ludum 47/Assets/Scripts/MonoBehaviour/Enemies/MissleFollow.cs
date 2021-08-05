using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    public Transform target;
    public float acceleration;
    public float maxSpeed;
    public float directionChangeSpeed;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if(GameManager.instance.playerReference != null)
        {
            target = GameManager.instance.playerReference.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StateManager.instance.playerDead)
        {
            Vector3 dir = (target.position - transform.position);
            dir.Normalize();
            //add an if statment that checks the speed
            if (Math.Abs(rb2d.velocity.y) + Math.Abs(rb2d.velocity.x) < maxSpeed)
            {
                rb2d.AddForce(dir * acceleration, ForceMode2D.Impulse);
            }
            // if it wants to change direction on an axis add more force help with the direction change.
            if ((dir.x > 0 && rb2d.velocity.x < 0) || (dir.x < 0 && rb2d.velocity.x > 0))
            {
                rb2d.AddForce(new Vector2(dir.x * acceleration * directionChangeSpeed, 0), ForceMode2D.Impulse);
            }
            if ((dir.y > 0 && rb2d.velocity.y < 0) || (dir.y < 0 && rb2d.velocity.y > 0))
            {
                rb2d.AddForce(new Vector2(0, dir.y * acceleration * directionChangeSpeed), ForceMode2D.Impulse);
            }

            float RotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, RotationZ - 90);
        }

    }
}
