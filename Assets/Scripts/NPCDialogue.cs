using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private int maxDistance;
    [SerializeField] private LayerMask npcLayer;
    [SerializeField] private GameObject EButton;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] public string[] standardDialog;
    [SerializeField] public string[] afterFirstLevel;
    [SerializeField] public string[] afterSecondLevel;
    [SerializeField] public string[] afterThirdLevel;
    [SerializeField] private TextMeshProUGUI npcText;

    bool isDialogueStarted = false;
    int currentStroke = 0;
    [HideInInspector] public string[] currentArray;

    private void Start()
    {
        currentArray = standardDialog;
    }
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, npcLayer) && !isDialogueStarted)
        {
            EButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.FindObjectOfType<PlayerController>().enabled = false;
                GameObject.FindObjectOfType<FirstPersonCameraController>().enabled = false;
                DialoguePanel.SetActive(true);
                isDialogueStarted = true;
            }
        }
        else
        {
            EButton.SetActive(false);

        }

        if (isDialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(currentStroke >= currentArray.Length)
                {
                    isDialogueStarted = false;
                    GameObject.FindObjectOfType<PlayerController>().enabled = true;
                    GameObject.FindObjectOfType<FirstPersonCameraController>().enabled = true;
                    DialoguePanel.SetActive(false);
                    currentStroke = 0;
                }
                npcText.text = currentArray[currentStroke++];

            }
        }
    }
}
