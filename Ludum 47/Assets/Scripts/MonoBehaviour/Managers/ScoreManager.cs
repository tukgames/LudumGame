﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }

    public float score;
    public float multiplier;

    public float timeToLoseMult;
    public float timeGainMult;

    [HideInInspector] public float timerLose;
    float timerGain;

    bool timerRunning;
    public multiplierBar multBar;
    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        score = 0;
        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(multiplier);
        if (timerRunning)
        {
            // Reset multiplier if the time it takes to lose multiplier occurs
            timerLose += Time.deltaTime;

            if(timerLose >= timeToLoseMult)
            {
                //Debug.Log("happened");
                timerLose = 0;
                multiplier = 1;
               
            }
        }

        timerGain += Time.deltaTime;
    }

    public void EnemyKilled(int value)
    {
        // Add score based on enemy value and multiplier
        score += value * multiplier;
        // Resets mult loss timer
        timerLose = 0;
        
        
        if(timerGain <= timeGainMult)
        {
            multiplier += 1;

        }

        timerGain = 0;
    }

    public void StopLoseTimer()
    {
        timerRunning = false;
    }

    public void ResumeLoseTimer()
    {
        timerRunning = true;
    }
}
