using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float xRotationSpeed;
    [SerializeField] private float yRotationSpeed;
    [SerializeField] private Vector2 euler;

    private void Update()
    {

        euler.x -= Input.GetAxis("Mouse Y") * yRotationSpeed * Time.deltaTime;
        euler.x = Mathf.Clamp(euler.x, -60.0f, 60.0f);
        transform.localEulerAngles = euler;

        player.transform.Rotate(new Vector3(0, Input.GetAxisRaw("Mouse X") * yRotationSpeed * Time.deltaTime, 0));
    }
}
