using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody rb;
    
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
        
        gameObject.transform.Translate(new Vector3(x * speed * Time.deltaTime,0,z * speed * Time.deltaTime));

        
    }

    private void FixedUpdate()
    {
        if (jump > 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(groundCheck.transform.position, 0.1f, whatIsGround);
            if (hitColliders.Length > 0)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }


}
