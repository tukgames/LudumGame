using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoors : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject door1;
    public GameObject door2;

    public WreckingBallBoss wBoss;

    public float doorSpeed;
    [HideInInspector]
    public bool active;

    bool doorsClosed;

    
    void Start()
    {
        active = true;
        doorsClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoors()
    {
        if (active && !doorsClosed)
        {
            Camera.main.GetComponent<ShakeBehavior>().TriggerShake();
            Debug.Log("close door");
            StartCoroutine(Close(door1));
            StartCoroutine(Close(door2));
            doorsClosed = true;
        }
    }

    public void OpenDoors()
    {
        Debug.Log("open door");

        StartCoroutine(Open(door1));
        StartCoroutine(Open(door2));

        doorsClosed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CloseDoors();
            if(wBoss != null)
            {
                wBoss.StartRoutine(collision.transform);
            }
        }
    }

    public IEnumerator Open(GameObject door)
    {
        float timer = 0;

        while (door.transform.localScale.x > 0)
        {
            door.transform.localScale = new Vector3(0.6f - (0.6f * timer / doorSpeed), door.transform.localScale.y, door.transform.localScale.z);

            timer += Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator Close(GameObject door)
    {
        float timer = 0;

        while (door.transform.localScale.x <= 0.6)
        {
            door.transform.localScale = new Vector3(0.6f * timer / doorSpeed, door.transform.localScale.y, door.transform.localScale.z);

            timer += Time.deltaTime;

            yield return null;
        }
    }
}
