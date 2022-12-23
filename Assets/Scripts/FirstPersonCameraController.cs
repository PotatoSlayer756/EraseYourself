using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float xRotationSpeed;
    [SerializeField] private float yRotationSpeed;
    [SerializeField] private float maxY, minY;
    private Vector2 euler;
    private Rigidbody playerRb;
    private void Start()
    {
        Application.targetFrameRate = -1;
        playerRb = player.GetComponentInChildren<Rigidbody>();
    }
    private void LateUpdate()
    {

        euler.x -= Input.GetAxis("Mouse Y") * xRotationSpeed * Time.deltaTime;
        
        euler.x = Mathf.Clamp(euler.x, minY, maxY);
        transform.localEulerAngles = euler;

    }

    private void FixedUpdate()
    {
        playerRb.angularVelocity = new Vector3(0, Input.GetAxis("Mouse X") * yRotationSpeed, 0);
        
    }
}
