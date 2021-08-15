using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunBoss : MonoBehaviour
{
    // Start is called before the first frame update

    Coroutine runRoutine;

    //public int rotAmount;

    public float fireInterval;

    public Vector2 rotationRange;
    public float rotationSpeed;

    public int numGuns;
    public float chargeTime;
    public float lifeTime;

    //public GameObject bulletPrefab;
    //list of lasers
    public List<RailGun> railGuns;

    public RailGun RailGunPrefab;
    public void Starting()
    {
        railGuns = new List<RailGun>();

        //create railguns
        for (int i = 0; i < numGuns; i++)
        {
            RailGun rg = gameObject.AddComponent<RailGun>();
            match(rg);

            rg.chargeTime = chargeTime;
            rg.lifeTime = lifeTime;
            railGuns.Add(rg);
        }

        rotationSpeed = railGuns[0].chargeTime + railGuns[0].lifeTime;


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
            Fire();
            StartCoroutine(Rotate());
            yield return new WaitForSeconds(rotationSpeed);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(fireInterval);
        }

    }

    public void Fire()
    {
        for(int i = 0; i < numGuns; i++)
        {
            //start the fire routine for each gun and give it an accurate vector to aim at
            float addon = ((float)i / numGuns)*360;
            //Debug.Log(i + " Count:" + railGuns.Count);
            //Debug.Log("ran through rail gun " + railGuns[i].chargeTime);
            //Debug.Log((i / numGuns) * 360);
            railGuns[i].StartRailGun(generateVector(transform.localEulerAngles.z + addon));
        }
    }

    public IEnumerator Rotate()
    {
        float amountToRotate = Random.Range(rotationRange.x, rotationRange.y);

        float timer = 0;

        while (timer < rotationSpeed)
        {
            transform.Rotate(0, 0, amountToRotate / rotationSpeed * Time.deltaTime);
            //set the lines
            for (int i = 0; i < numGuns; i++)
            {
                //start the fire routine for each gun and give it an accurate vector to aim at
                float addon = ((float)i / numGuns) * 360;
                
                railGuns[i].SetLine(generateVector(transform.localEulerAngles.z + addon));
            }

            timer += Time.deltaTime;

            yield return null;
        }
    }

    public Vector3 generateVector(float rotationZ)
    {
        float radians = rotationZ * (Mathf.PI / 180);
        Vector3 degreeVector = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
        return transform.position + degreeVector;
    }

    public void match(RailGun rg)
    {
        rg.lineColor = RailGunPrefab.lineColor;
        rg.startWidth = RailGunPrefab.startWidth;
        rg.endWidth = RailGunPrefab.endWidth;
        rg.lineLength = RailGunPrefab.lineLength;
        rg.alphaChangeSpeed = RailGunPrefab.alphaChangeSpeed;
        rg.particlePrefab = RailGunPrefab.particlePrefab;
        rg.particleSpawn = RailGunPrefab.particleSpawn;
        rg.layer_mask = RailGunPrefab.layer_mask;
    }
}
