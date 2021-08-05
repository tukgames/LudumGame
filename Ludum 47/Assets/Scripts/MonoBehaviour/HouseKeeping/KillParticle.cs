using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticle : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    public float liveTime;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= liveTime)
        {

            if (StateManager.instance.playerDead)
            {
                if(transform.tag != "Kill player")
                {
                    Destroy(gameObject);
                }
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
