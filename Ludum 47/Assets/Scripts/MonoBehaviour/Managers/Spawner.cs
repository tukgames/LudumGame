using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject spawnObject()
    {
        GameObject pl = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        return pl;
    }
}
