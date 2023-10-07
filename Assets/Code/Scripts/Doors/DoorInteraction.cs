using Unity.VisualScripting;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private DoorController[] doors;
    private bool isOpened = false;

    public bool requiresKey = false;
    public KeyName requiredKey;
    public string defaultLayer = "Default";

    public AudioClip doorOpenSound;
    private void Start()
    {
        doors = GetComponentsInChildren<DoorController>();
    }

    public void Interact()
    {
        OpenDoors();
    }

    public void ToggleOutline(bool state)
    {
        // No outline for doors
    }

    public void OpenDoors()
    {
        if (isOpened) return;

        if (requiresKey && !PlayerInventory.HasKey(requiredKey.name))
        {
            // Display a message in the UI
            string message = requiredKey.roomName + " is locked";
            UIManager.Instance.StartDisplayingMessage(message, 1f);
        }

        if (!requiresKey || (requiresKey && PlayerInventory.HasKey(requiredKey.name)))
        {
            isOpened = true;

            if (requiresKey) 
            {
                // Display a message in the UI
                string message = "Used " + requiredKey.roomName + " key";
                UIManager.Instance.StartDisplayingMessage(message, 1f);
            }

            if (doorOpenSound != null)
            {
                AudioSource.PlayClipAtPoint(doorOpenSound, transform.position);
            }


            foreach (DoorController controller in doors)
            {
                controller.OpenDoor();
            }

            // Change the layer of the door and its children
            ChangeLayerRecursively(transform, LayerMask.NameToLayer(defaultLayer));
        }
    }


    // Recursive function to change the layer of a GameObject and its children
    private void ChangeLayerRecursively(Transform transform, int newLayer)
    {
        transform.gameObject.layer = newLayer;
        foreach (Transform child in transform)
        {
            ChangeLayerRecursively(child, newLayer);
        }
    }
}
