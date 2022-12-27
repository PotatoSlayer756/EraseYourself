using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField] private List<GameObject> neededPixels;
    public int portalIndex;
    [SerializeField] private NPCDialogue npcDialogue;
    public static int currentAbsorbedPixels = 0;

    int neededPixelsCount;

    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        neededPixelsCount = neededPixels.Count;
    }

    private void Update()
    {
        for (int i = 0; i < neededPixels.Count; i++)
        {
            if (!neededPixels[i])
            {
                neededPixels.RemoveAt(i);
            }
        }
        if (neededPixels.Count == 0)
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                currentAbsorbedPixels += neededPixelsCount;
                DataContainer.checkpointIndex = 0;
                SceneManager.LoadScene("HubScene");

            switch (portalIndex)
            {
                case 1:
                    NPCDialogue.superCurrentArray = npcDialogue.afterFirstLevel;
                    break;
                case 2:
                    NPCDialogue.superCurrentArray = npcDialogue.afterSecondLevel;
                    break;
                case 3:
                    NPCDialogue.superCurrentArray = npcDialogue.afterThirdLevel;
                    break;

            }

        }
    }
}
