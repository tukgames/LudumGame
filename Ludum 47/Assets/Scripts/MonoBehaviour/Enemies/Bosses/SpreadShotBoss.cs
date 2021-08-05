using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotBoss : MonoBehaviour
{
    // Start is called before the first frame update

    Coroutine runRoutine;

    //public int rotAmount;

    public float fireSpeed;
    public int fireAmount;

    public float fireInterval;

    public Vector2 rotationRange;
    public float rotationSpeed;

    public GameObject bulletPrefab;

    public List<GameObject> guns;
    void Start()
    {
        runRoutine = StartCoroutine(RunRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    IEnumerator RunRoutine()
    {
        while (true)
        {
            StartCoroutine(FireRoutine());
            yield return new WaitForSeconds(fireAmount * fireSpeed);
            StartCoroutine(Rotate());

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(fireInterval + rotationSpeed);
        }
        
    }

    public IEnumerator FireRoutine()
    {
        int count = 0;

        while(count < fireAmount)
        {
            Fire();
            count++;
            yield return new WaitForSeconds(fireSpeed);
        }

        //StartCoroutine(Rotate());
    }

    public void Fire()
    {
        foreach(GameObject gun in guns)
        {
            Vector3 spawnPos = gun.transform.GetChild(0).transform.position;

            Quaternion rot = gun.transform.rotation;// * transform.rotation;//Quaternion.Euler(gun.transform.eulerAngles.x + transform.eulerAngles.x, gun.transform.eulerAngles.y + transform.eulerAngles.y, gun.transform.eulerAngles.z + transform.eulerAngles.z);

            //s Debug.Log("given rotation " + rot.z);

           // Debug.Log(gun.transform.eulerAngles.z + "   " + transform.eulerAngles.z);

            //Debug.Log("Those added  " + rot.eulerAngles.z);

            //float rot = gun.transform.eulerAngles.z + transform.eulerAngles.z;

            //Debug.Log(rot);



            GameObject bullet = Instantiate(bulletPrefab, spawnPos, rot);

            bullet.transform.rotation = rot;

            bullet.GetComponent<Bullet>().Fire(rot);
        }
    }

    public IEnumerator Rotate()
    {
        float amountToRotate = Random.Range(rotationRange.x, rotationRange.y);

        float timer = 0;

        while(timer < rotationSpeed)
        {
            transform.Rotate(0,0,amountToRotate / rotationSpeed * Time.deltaTime);

            timer += Time.deltaTime;

            yield return null;
        }
    }


}

