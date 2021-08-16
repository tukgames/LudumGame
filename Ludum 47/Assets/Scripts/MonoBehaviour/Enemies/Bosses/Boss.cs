using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    // Start is called before the first frame update

    //public GameObject healthBarPrefab;


    public GameObject healthBarPrefab;
    HealthBar healthBar;
    public Vector3 offset;

    public BossDoors doors;
    public int difficultyRating;


    private void Start()
    {
       // CurrentCanvas = GameObject.Find("Canvas");
        startingHitPoints = hitpoints;
        
        BossManager.instance.alreadyBoss = true;

        healthBar = Instantiate(healthBarPrefab, transform.position, Quaternion.identity).GetComponent<HealthBar>();

        healthBar.target = transform;
        healthBar.offset = offset;


        


    }




    public override void DecreaseHealthBar()
    {
        //decrease health bar
        if(healthBar!= null)
        {
            //healthBar.GetComponent<RectTransform>().position = new Vector3(0, -40, 0);
            Debug.Log("Decreased health bar to " + hitpoints + " devided by " + startingHitPoints);

            healthBar.updateBar(hitpoints, startingHitPoints);
            
        }
    }

    public override void DestroyHealthBar()
    {
        //destroy health bar
        if(healthBar != null)
        {
            //healthBar.GetComponent<SpriteRenderer>().fillAmount = (float)hitpoints / startingHitPoints;
            Destroy(healthBar.gameObject);
        }
    }

    private void OnDestroy()
    {
        DestroyHealthBar();
        BossManager.instance.alreadyBoss = false;
        //Debug.Log("boss was destroyed");
    }

    public override void OpenDoors()
    {
        if (doors != null)
        {
            PostManager.instance.ResetVignette();
            doors.active = false;
            doors.OpenDoors();
        }
    }


}
