using UnityEngine;


public class UIManager : MonoBehaviour
{
    public GameObject interactPanel; // Reference to the interact UI element

    private PlayerInteraction playerInteraction;


    private void Awake()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
    }
    private void OnEnable()
    {
        // Subscribe to the PlayerInteraction's event
        playerInteraction.OnInteractableStateChanged += HandleInteractableStateChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from the PlayerInteraction's event when this script is disabled
        playerInteraction.OnInteractableStateChanged -= HandleInteractableStateChanged;
    }

    // Handle changes in the interactable state
    private void HandleInteractableStateChanged(bool isInteractable)
    {
        interactPanel.SetActive(isInteractable);
    }
}