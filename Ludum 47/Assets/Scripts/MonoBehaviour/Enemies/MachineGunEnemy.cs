using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{

    Wander wander;

    public Transform target;

    public float fireSpeed;
    public float bulletSpeed;

    public float rotateSpeed;

    public GameObject bulletPrefab;

    bool firing;
    // Start is called before the first frame update
    void Start()
    {
        firing = false;
        wander = GetComponent<Wander>();
        target = GameManager.instance.playerReference.transform;
        //wander.StartWander();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StateManager.instance.playerDead)
        {
            Rotate();
        }
    }

    public void Rotate()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        Vector3 dir = (target.position - transform.position);
        dir.Normalize();


        float RotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        
        if(RotationZ < 0)
        {
            RotationZ += 360;
        }
        float zTrans = UnwrapAngle(transform.localEulerAngles.z);
        

        float plusRot = zTrans + (rotateSpeed * Time.deltaTime);
        float minusRot = zTrans - (rotateSpeed * Time.deltaTime);
        Debug.Log(RotationZ + " " + plusRot + " " + minusRot + " " + zTrans);
        if (plusRot > RotationZ && minusRot < RotationZ)
        {
            Debug.Log(transform.name + " has the correct rot");
            transform.rotation = Quaternion.Euler(0, 0, RotationZ);
        }
        else
        {
            if (plusRot > 360)
            {
                plusRot -= 360;
            }
            if (minusRot < 0)
            {
                minusRot += 360;
            }

            float plusDistance = Mathf.Abs(plusRot - RotationZ);
            if(plusDistance > 180)
            {
                plusDistance = 360 - plusDistance;
            }
            float minusDistance = Mathf.Abs(minusRot - RotationZ);
            if(minusDistance > 180)
            {
                minusDistance = 360 - minusDistance;
            }

            if (plusDistance > minusDistance) 
            {
                
                transform.rotation = Quaternion.Euler(0, 0, minusRot);
                //Debug.Log(transform.name + " has rotated right");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, plusRot);
                //Debug.Log(transform.name + " rotated left");
            }
        }
        
        

        
        


        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!firing)
            {
                wander.StopWander();
                StartCoroutine(Fire());
                firing = true;
            }
        }
    }

    public IEnumerator Fire()
    {
        Vector3 loc = transform.GetChild(0).GetChild(0).position;

        Quaternion rot = transform.rotation;

        


        GameObject bullet = Instantiate(bulletPrefab, loc, rot);
        bullet.GetComponent<Bullet>().Fire(rot);
        bullet.GetComponent<Bullet>().speed = bulletSpeed;

        yield return new WaitForSeconds(fireSpeed);

        firing = false;
        wander.StopWander();
    }

    private static float UnwrapAngle(float angle)
    {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }


}
