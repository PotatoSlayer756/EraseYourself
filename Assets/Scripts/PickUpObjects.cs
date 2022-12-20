using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    [SerializeField] private LayerMask pickupableLayer;
    [SerializeField] private Transform handsPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private Camera cam;
    [SerializeField] GameObject rmbIcon;
    bool isPicked = false;
    GameObject pickedObject;
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, pickupableLayer))
        {
            rmbIcon.SetActive(true);
            if (Input.GetButtonDown("Fire2") && !isPicked)
            {
                isPicked = true;
                pickedObject = hit.transform.gameObject;
                pickedObject.transform.position = handsPosition.position;
                pickedObject.transform.SetParent(handsPosition);
            }
            else if (Input.GetButtonDown("Fire2") && isPicked)
            {
                isPicked = false;
                pickedObject.transform.SetParent(null);
                pickedObject = null;
            }
        }    
        else
        {
            rmbIcon.SetActive(false);
        }
    }

}
