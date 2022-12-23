using System;
using UnityEngine;

public class RespawnOnCheckpoint : MonoBehaviour
{
    [SerializeField] private int index;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(DataContainer.checkpointIndex == index)
        {
            player.position = transform.position;

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(index > DataContainer.checkpointIndex)
            {
                DataContainer.checkpointIndex = index;

            }
        }
    }

}
