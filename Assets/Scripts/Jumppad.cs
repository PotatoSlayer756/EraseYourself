using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    [SerializeField] private float jumppadForce;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumppadForce, ForceMode.Impulse);
    }
}
