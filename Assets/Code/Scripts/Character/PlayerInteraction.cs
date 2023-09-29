using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust this as needed
    private Camera playerCamera; // Reference to the player's camera
    private RaycastHit interactableHit;
    private bool hasHit;

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
        if (interactableHit.collider != null && Input.GetKeyDown(KeyCode.F) && hasHit)
        {
            DoorInteraction doorInteraction = interactableHit.collider.GetComponent<DoorInteraction>();
            KeyInteraction keyInteraction = interactableHit.collider.GetComponent<KeyInteraction>();

            if (doorInteraction != null)
            {
                    doorInteraction.OpenDoors();
            }

            if (keyInteraction != null)
            {
                    keyInteraction.Addkey();
            }
        }
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        // Cast a ray from the camera's position in the forward direction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, LayerMask.GetMask("Interactable")))
        {
            interactableHit = hit;
            hasHit = true;
            // Notify subscribers (the UIManager) that the interactable state has changed
            if (OnInteractableStateChanged != null)
            {
                OnInteractableStateChanged(true);
            }
        }
        else
        {
            hasHit = false;
            
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
