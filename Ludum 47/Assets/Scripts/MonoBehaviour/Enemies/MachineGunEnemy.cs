using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{

    Wander wander;
    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<Wander>();
        //wander.StartWander();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
