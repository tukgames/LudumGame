using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    void Start()
    {
        if (GameManager.instance.playerReference != null)
        {
            target = GameManager.instance.playerReference.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StateManager.instance.playerDead)
        {
            Vector3 dir = (target.position - transform.position);
            dir.Normalize();


            float RotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, RotationZ + 180);
        }
    }
}
