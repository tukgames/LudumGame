using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static BossManager instance;
    public int distanceBetweenDiff;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public bool alreadyBoss;
    void Start()
    {
        alreadyBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
