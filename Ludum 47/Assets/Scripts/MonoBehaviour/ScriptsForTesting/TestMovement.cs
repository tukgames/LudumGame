using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2();

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        rb.AddForce(dir * speed * Time.deltaTime, ForceMode2D.Impulse);


    }
}
