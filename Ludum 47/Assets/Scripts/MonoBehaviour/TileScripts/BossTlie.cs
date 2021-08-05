using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTlie : MonoBehaviour
{
    //this will handle spawning in the boss as well as the enemies surrounding the boss

    public List<GameObject> possibleBosses;
    public BossDoors doorHandler;


    // Start is called before the first frame update

    //public GameObject boss;
    void Start()
    {
        //GetComponent<Tile>().currentEnemies.Add(boss);
        //Decide which boss to spawn
        

        int dist = Mathf.Abs(GetComponent<Tile>().xValue) + Mathf.Abs(GetComponent<Tile>().yValue);

        for (int i = possibleBosses.Count - 1; i >= 0; i--)
        {
            if(possibleBosses[i].GetComponent<Boss>().difficultyRating * BossManager.instance.distanceBetweenDiff > dist)
            {
                //Debug.Log("Removed " + possibleBosses[i].transform.name);
                possibleBosses.Remove(possibleBosses[i]);
            }
        }

        int rand = Random.Range(0, possibleBosses.Count);

        //Debug.Log(rand);

        GameObject bossToSpawn = possibleBosses[rand];

        GameObject boss = Instantiate(bossToSpawn, transform.position, Quaternion.identity);
        GetComponent<Tile>().currentEnemies.Add(boss);
        boss.GetComponent<Boss>().doors = doorHandler;
        if(boss.GetComponent<WreckingBallBoss>() != null)
        {
            doorHandler.wBoss = boss.GetComponent<WreckingBallBoss>();
        }

        //need to give the boss the door handler

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
