using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunEnemy : Enemy
{
    // Start is called before the first frame update
    public Transform target;
    bool rotate;
    Quaternion frozenRotation;

    [HideInInspector]
    public bool isHappening;
    void Start()
    {
        rotate = true;
        isHappening = false;

        if (GameManager.instance.playerReference != null)
        {
           target = GameManager.instance.playerReference.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StateManager.instance.playerDead && rotate)
        {
            Rotate();
        } else if (!rotate)
        {
            transform.rotation = frozenRotation;
        }
    }


    public void Rotate()
    {
        Vector3 dir = (target.position - transform.position);
        dir.Normalize();


        float RotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, RotationZ - 90);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player(Clone)")
        {
            //Debug.Log(collision.tag);
        }
        if (collision.transform.CompareTag("Player") && !isHappening)
        {
            Debug.Log("realized was player");

            Rotate();
            Debug.Log("Started rail gun process");
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Wander>().StopWander();
            rotate = false;
            frozenRotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z);

            GetComponent<RailGun>().StartRailGun(target);
            isHappening = true;
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Stopped rail gun process");            
            GetComponent<Wander>().StartWander();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            rotate = true;
            //frozenRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }*/

    public void ResetEnemy()
    {
        GetComponent<Wander>().StartWander();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        rotate = true;
        isHappening = false;
    }

    
}
