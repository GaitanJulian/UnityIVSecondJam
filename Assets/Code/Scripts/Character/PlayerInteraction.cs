using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust this as needed
    private Camera playerCamera; // Reference to the player's camera

    // Define a delegate for interactable state changes
    public delegate void InteractableStateChanged(bool isInteractable);
    public event InteractableStateChanged OnInteractableStateChanged;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Continuously shoot the raycast
        ShootRaycast();
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        // Cast a ray from the camera's position in the forward direction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, LayerMask.GetMask("Interactable")))
        {
            HandleInteraction(hit);

            // Notify subscribers (the UIManager) that the interactable state has changed
            if (OnInteractableStateChanged != null)
            {
                OnInteractableStateChanged(true);
            }
        }
        else
        {
            // Notify subscribers (the UIManager) that the interactable state has changed
            if (OnInteractableStateChanged != null)
            {
                OnInteractableStateChanged(false);
            }
        }


    }

    void HandleInteraction(RaycastHit hit)
    {
        DoorInteraction doorInteraction = hit.collider.GetComponent<DoorInteraction>();
        KeyInteraction keyInteraction = hit.collider.GetComponent<KeyInteraction>();

        if (doorInteraction != null)
        {
            // Call the OpenDoors method of the DoorInteraction script
            if (Input.GetKeyDown(KeyCode.F))
            {
                doorInteraction.OpenDoors();
            }
        }
        else if (keyInteraction != null)
        {
            // Call the Addkey method of the KeyInteraction script
            if (Input.GetKeyDown(KeyCode.F))
            {
                keyInteraction.Addkey();
            }
        }
    }


    void OnDrawGizmos()
    {
        // Ensure the playerCamera is not null
        if (playerCamera != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionDistance);
        }
    }
}
