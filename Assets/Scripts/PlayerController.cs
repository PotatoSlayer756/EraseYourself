using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody rb;
    Collider[] hitColliders;

    //bool isGrounded = true;
    [SerializeField] GameObject groundCheck;

    private float x,z,jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        jump = Input.GetAxis("Jump");
        rb.velocity = transform.TransformDirection(x * speed, rb.velocity.y, z * speed);
        //transform.Translate(new Vector3(x * speed * Time.deltaTime, rb.velocity.y * Time.deltaTime, z * speed * Time.fixedDeltaTime));


    }

    private void FixedUpdate()
    {
        hitColliders = Physics.OverlapSphere(groundCheck.transform.position, 0.2f, whatIsGround);
        if (jump > 0)
        {
            if (hitColliders.Length > 0)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }


}
