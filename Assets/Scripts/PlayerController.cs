using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private float x;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (x > 0 || x < 0)
        {
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
        }
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
        }
    }
}
