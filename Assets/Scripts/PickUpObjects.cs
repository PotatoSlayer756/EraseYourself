using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    [SerializeField] private LayerMask pickupableLayer;
    //[SerializeField] private Transform handPoint;
    [SerializeField] private float maxDistance;
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance, pickupableLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100.0f, Color.yellow);
            Debug.Log("Hit");
        }
    }
}
