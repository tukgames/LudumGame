using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragBack : MonoBehaviour
{
    // Start is called before the first frame update

    

    Rigidbody2D rb;
    Vector3 origionalMousePosition;
    Vector3 draggedMousePosition;
    public float speed;


    GameObject myLine;
    LineRenderer lr;
    public Color lineColor;
    public float startWidth;
    public float endWidth;
    public Material mat;

    public float maxDragSpeed;
    public float maxSpeed;


    public ParticleSystem particlePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        myLine = new GameObject();
        myLine.transform.position = Vector3.zero;
        myLine.AddComponent<LineRenderer>();
        lr = myLine.GetComponent<LineRenderer>();
        mat.color = lineColor;
        lr.material = mat;
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.startWidth = startWidth;
        lr.endWidth = endWidth;
       



        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StateManager.instance.playerDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                origionalMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                draggedMousePosition = Input.mousePosition;
                lr.enabled = false;
                moveCharacter();


            }


            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.7f * Time.deltaTime);

            drawLine();
        } 
    }


    void moveCharacter()
    {
        var shootVector = Camera.main.ScreenToWorldPoint(origionalMousePosition) - Camera.main.ScreenToWorldPoint(draggedMousePosition);

        if(Math.Abs(shootVector.x) + Math.Abs(shootVector.y) > maxDragSpeed)
        {
            float devideBy = (Math.Abs(shootVector.x) + Math.Abs(shootVector.y)) / maxDragSpeed;
            shootVector /= devideBy;
        }

        /*if ((Math.Abs(rb.velocity.x + shootVector.x) + Math.Abs(rb.velocity.y + shootVector.y) < Math.Abs(rb.velocity.x) + Math.Abs(rb.velocity.y)))
        {
            rb.AddForce(shootVector * speed, ForceMode2D.Impulse);
        } else if ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) < maxSpeed)
        {
            float speedDifference = maxSpeed - ((Math.Abs(rb.velocity.x) + Math.Abs(rb.velocity.y)));
            float forceToAddDevidedByDifference = (Math.Abs(shootVector.x) + Math.Abs(shootVector.y)) / speedDifference;
            if(forceToAddDevidedByDifference > 1)
            {
                shootVector /= forceToAddDevidedByDifference;
                rb.AddForce(shootVector * speed, ForceMode2D.Impulse);
            } else
            {
                rb.AddForce(shootVector * speed, ForceMode2D.Impulse);
            }


        }*/
        rb.velocity = Vector2.zero;
        rb.AddForce(shootVector * speed, ForceMode2D.Impulse);
       
    }

    void drawLine()
    {
        if (Input.GetMouseButton(0))
        {
            lr.enabled = true;
            //Debug.Log("Drawn Line");
            //Debug.DrawLine(transform.position, transform.position + (origionalMousePosition - Camera.main.ScreenToWorldPoint(Input.mousePosition)), Color.white);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1,transform.position + (Camera.main.ScreenToWorldPoint(origionalMousePosition) - Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            //Debug.DrawLine(Vector3.zero, new Vector3(0,2,0), Color.red);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Instantiate(particlePrefab, contact.point, Quaternion.Euler(0, 0, 0));
    }


    public void OnPlayerDeath()
    {
        lr.enabled = false;
    }
}
