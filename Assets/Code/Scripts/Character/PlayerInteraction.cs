using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust this as needed
    private Camera playerCamera; // Reference to the player's camera
    private RaycastHit interactableHit;
    private bool hasHit;
    private CandleFuel candeFuel;
    // Define a delegate for interactable state changes
    public delegate void InteractableStateChanged(bool isInteractable);
    public event InteractableStateChanged OnInteractableStateChanged;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        candeFuel = FindObjectOfType<CandleFuel>();
    }

    void Update()
    {
        // Continuously shoot the raycast
        ShootRaycast();
        if (interactableHit.collider != null && Input.GetKeyDown(KeyCode.F) && hasHit)
        {
            DoorInteraction doorInteraction = interactableHit.collider.GetComponent<DoorInteraction>();
            KeyInteraction keyInteraction = interactableHit.collider.GetComponent<KeyInteraction>();
            ScreamerEvent screamer = interactableHit.collider.GetComponent<ScreamerEvent>();

            if (doorInteraction != null)
            {
                    doorInteraction.Interact();
            }

            if (keyInteraction != null)
            {
                    keyInteraction.Interact();
            }

            if (screamer != null)
            {
                screamer.ActivateScreamer();
            }

            // Check if the hit object has the "Candle" tag
            if (interactableHit.collider.CompareTag("Candle"))
            {
                candeFuel.RefillCandle();
                Destroy(interactableHit.collider.gameObject);
            }
        }
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        // Cast a ray from the camera's position in the forward direction
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, LayerMask.GetMask("Interactable")))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactableHit = hit;
                hasHit = true;
                // Toggle the component ON for the object the player is looking at
                interactable.ToggleOutline(true);
                if (OnInteractableStateChanged != null)
                {
                    OnInteractableStateChanged(true);
                }
            }
        }
        else
        {
            if (hasHit && interactableHit.collider != null) // Check if the player was previously looking at an interactable
            {
                IInteractable previousInteractable = interactableHit.collider.GetComponent<IInteractable>();
                if (previousInteractable != null)
                {
                    // Toggle the component OFF for the object the player was previously looking at
                    previousInteractable.ToggleOutline(false);
                }
            }
            hasHit = false;
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
