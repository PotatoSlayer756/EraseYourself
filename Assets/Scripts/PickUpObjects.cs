using UnityEngine;
using TMPro;

public class PickUpObjects : MonoBehaviour
{
    [SerializeField] private LayerMask pickupableLayer;
    [SerializeField] private Transform handsPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject rmbIcon;
    [SerializeField] private GameObject absorbTip;
    [SerializeField] private TextMeshProUGUI absorbedPixelsText;

    private GameObject portal;

    private GameObject[] allPixelsOnLevel;
    private int pixelsOnLevelAmount;

    private int absorbedPixels = 0;
    private bool isPicked = false;
    private Rigidbody rb;
    private void Start()
    {
        allPixelsOnLevel = GameObject.FindGameObjectsWithTag("BrokenPixel");
        pixelsOnLevelAmount = allPixelsOnLevel.Length;
        portal = GameObject.FindGameObjectWithTag("Portal");
        portal.SetActive(false);
    }

    GameObject pickedObject;
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, pickupableLayer))
        {
            if (!isPicked) rmbIcon.SetActive(true);

            if (Input.GetButtonDown("Fire2") && !isPicked)
            {
                isPicked = true;
                pickedObject = hit.transform.gameObject;
                pickedObject.transform.position = handsPosition.position;
                pickedObject.transform.SetParent(handsPosition);

                if (pickedObject.gameObject.tag == "BrokenPixel")
                {
                    pickedObject.gameObject.GetComponentInChildren<Animator>().SetBool("isPicked", isPicked);
                    absorbTip.SetActive(true);
                }

                if (pickedObject.GetComponent<Rigidbody>() != null)
                {
                    pickedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
            else if (Input.GetButtonDown("Fire2") && isPicked)
            {
                if (pickedObject.gameObject.tag == "BrokenPixel")
                {
                    pickedObject.gameObject.GetComponentInChildren<Animator>().SetBool("isPicked", !isPicked);
                    absorbTip.SetActive(false);
                }

                if(pickedObject.GetComponent<Rigidbody>() != null)
                {
                    pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                }

                isPicked = false;
                pickedObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
        else
        {
            rmbIcon.SetActive(false);
        }

        if (pickedObject != null && pickedObject.gameObject.tag == "BrokenPixel" && Input.GetButtonDown("Fire1"))
        {
            absorbTip.SetActive(false);
            absorbedPixels++;
            Destroy(pickedObject);
            pickedObject = null;
            isPicked = false;
        }

        absorbedPixelsText.text = $"{absorbedPixels}";

        if(absorbedPixels == pixelsOnLevelAmount)
        {
            portal.SetActive(true);
        }
    }

}
