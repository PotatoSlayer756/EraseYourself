using System;
using UnityEngine;

public class RespawnOnCheckpoint : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private int index;
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

    private void Update()
    {
        if(DataContainer.checkpointIndex == index)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        else if (DataContainer.checkpointIndex != index)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
    }

}
