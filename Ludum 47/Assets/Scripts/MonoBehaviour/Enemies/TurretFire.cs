using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missilePrefab;
    public Transform target;
    public int shootSpeed;
    void Start()
    {
        if (GameManager.instance.playerReference != null)
        {
            target = GameManager.instance.playerReference.transform;
        } else
        {
            target = transform;
        }
        StartCoroutine(shootRoutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shootRoutine()
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime;

            if(timer >= shootSpeed)
            {
                if (!StateManager.instance.playerDead)
                {
                    //fire
                    GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
                    missile.GetComponent<MissleFollow>().target = target;
                    timer = 0;
                }
             
            }
            yield return null;
        }
    }
}
