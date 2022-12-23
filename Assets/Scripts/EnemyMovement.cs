using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed;

    private int currentPoint = 0;

    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, points[currentPoint].position, speed * Time.deltaTime);
        Debug.Log(currentPoint);
        if(gameObject.transform.position == points[currentPoint].position)
        {
            if(currentPoint == points.Length-1)
            {
                Array.Reverse(points);
                currentPoint = 0;
            }
            currentPoint++;
        }

    }
}
