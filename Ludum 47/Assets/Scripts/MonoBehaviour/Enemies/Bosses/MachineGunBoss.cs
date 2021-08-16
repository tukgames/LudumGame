using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBoss : MonoBehaviour
{
    Coroutine runRoutine;

    //public int rotAmount;

    public float fireSpeed;
    public int fireAmount;
    public float bulletSpeed;

    public float fireInterval;

    public Vector2 rotationRange;
    float rotationSpeed;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        runRoutine = StartCoroutine(RunRoutine());
        rotationSpeed = fireAmount * fireSpeed * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunRoutine()
    {
        while (true)
        {
            
            StartCoroutine(FireRoutine());
            StartCoroutine(Rotate());

            yield return new WaitForSeconds(fireAmount * fireSpeed);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(fireInterval);
        }
    }

    public void Fire()
    {
        Vector3 loc = transform.GetChild(0).GetChild(0).position;

        Quaternion rot = transform.rotation;

        GameObject bullet = Instantiate(bulletPrefab, loc, rot);
        bullet.GetComponent<Bullet>().Fire(rot);
        bullet.GetComponent<Bullet>().speed = bulletSpeed;

    }

    IEnumerator FireRoutine()
    {
        int count = 0;
        float startTime = Time.time;

        while (count < fireAmount)
        {
            Fire();
            count++;
            yield return new WaitForSeconds(fireSpeed);
        }
        //Debug.Log(Time.time - startTime);
    }

    public IEnumerator Rotate()
    {
        float amountToRotate = Random.Range(rotationRange.x, rotationRange.y);
        float startTime = Time.time;

        float timer = 0;

        while (timer < rotationSpeed)
        {
            transform.Rotate(0, 0, amountToRotate / rotationSpeed * Time.deltaTime);

            timer += Time.deltaTime;

            yield return null;
        }

        Debug.Log(Time.time - startTime);
    }
}
