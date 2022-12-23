using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField] private List<GameObject> neededPixels;
    [SerializeField] private PickUpObjects pickUpObjects;
    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {
        for(int i = 0; i<neededPixels.Count; i++)
        {
            if (!neededPixels[i])
            {
                neededPixels.RemoveAt(i);
            }
        }
        if(neededPixels.Count == 0)
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DataContainer.checkpointIndex = 0;
            SceneManager.LoadScene("HubScene");
        }
    }
}
