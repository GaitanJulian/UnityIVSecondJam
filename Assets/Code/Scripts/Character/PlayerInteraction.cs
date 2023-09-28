using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; // Adjust this as needed
    private Camera playerCamera; // Reference to the player's camera

    void Start()
    {
        // Assuming your player character has a camera as a child, you can find it like this:
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            // Cast a ray from the camera's position in the forward direction
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
            {
                DoorInteraction doorInteraction = hit.collider.GetComponent<DoorInteraction>();
                if (doorInteraction != null)
                {
                    // Call the OpenDoors method of the DoorInteraction script
                    doorInteraction.OpenDoors();
                }

                KeyInteraction keyInteraction = hit.collider.GetComponent<KeyInteraction>();
                if (keyInteraction != null) 
                {
                    keyInteraction.Addkey();
                }
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
