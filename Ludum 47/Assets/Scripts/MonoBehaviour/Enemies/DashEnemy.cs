using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : Enemy
{
    // Start is called before the first frame update
    public Transform target;
    public int rotSpeed = 15;
    public int launchForce = 20;

    [HideInInspector]
    // Stages: 0-Wander 1-Aim 2-Charge 3-Dash
    int stage = 0;
    float clock = 0;

    // Set body to the object that holds the DashAnimationManager
    DashAnimationManager animManager;
    public GameObject body;
    Rigidbody2D thisRB;
    void Start() {
        stage = 0;
        thisRB = this.GetComponent<Rigidbody2D>();
        

        // Dash animation manager
        animManager = body.GetComponent<DashAnimationManager>();

        // Grabs player reference
        if (GameManager.instance.playerReference != null) {
            target = GameManager.instance.playerReference.transform;
        }
    }

    // Update is called once per frame
    void Update() {
        if (!StateManager.instance.playerDead) {
            if (stage != 0) {
                GetComponent<Wander>().StopWander();
            }

            // Aiming
            if (stage == 1) {
                
                
                // Rotation towards target
                Vector3 dir = (target.position - transform.position).normalized;
                float RotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion targetRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, RotationZ);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);



                // Cancel velocity
                thisRB.velocity = new Vector2(0, 0);
                thisRB.angularVelocity = 0;

                // Animation
                if (clock >= 2 && !animManager.opened) {
                    animManager.openAnim();
                }
                
                // Clock logic
                clock += Time.deltaTime;
                if (clock >= 3) {
                    clock = 0;
                    stage++;
                    //Debug.Log("Stage 2");
                }

            }

            // Charge
            if (stage == 2) {
                //this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                

                // Clock logic
                clock += Time.deltaTime;
                if (clock >= 0) {
                    clock = 0;
                    stage++;
                    //Debug.Log("Stage 3");
                }
            }

            // Dash
            if (stage == 3) {
                /*
                float zdir = this.transform.rotation.z;
                Vector3 dashDir = new Vector3(launchForce*Mathf.Cos(zdir), launchForce * Mathf.Sin(zdir), 0);
                Debug.Log(dashDir);
                this.GetComponent<Rigidbody2D>().velocity = dashDir;
                */
                Vector3 dashDir = (target.position - this.transform.position).normalized;
                thisRB.velocity = dashDir * launchForce;


                stage++;
                //Debug.Log("Stage 4");
            }

            // Cooldown
            if (stage == 4) {
                if (clock >= 1) {
                    thisRB.velocity = Vector3.Lerp(thisRB.velocity, new Vector3(0, 0, 0), Time.deltaTime);
                }

                
                
                if (clock >= 4.25 && animManager.opened) {
                    animManager.closeAnim();
                }

                // Clock logic
                clock += Time.deltaTime;
                if (clock >= 5) {
                    clock = 0;
                    stage = 0;
                }
            }

        }

        
    }


    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.name == "Player(Clone)") {
            //Debug.Log(collision.tag);
        }
        if (collision.transform.CompareTag("Player") && stage == 0) {
            GetComponent<Wander>().StopWander();
            stage = 1;
            //Debug.Log("Stage 1");
            
        }
    }


    public void ResetEnemy() {
        //GetComponent<Wander>().StartWander();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        stage = 0;
    }
}
