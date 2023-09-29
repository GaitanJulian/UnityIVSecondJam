using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject interactPanel; // Reference to the interact UI element
    public GameObject messagePanel; // Reference to the message Panel
    public TextMeshProUGUI messageText;

    // Singleton instance
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private PlayerInteraction playerInteraction;

    private Coroutine messageCoroutine; // Coroutine for displaying messages

    private void Awake()
    {
        // Ensure there's only one instance of UIManager in the scene
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

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

    private IEnumerator DisplayMessage(string message, float displayTime)
    {
        messageText.text = message;
        messagePanel.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        messagePanel.SetActive(false);
    }

    // Method to start displaying a message
    public void StartDisplayingMessage(string message, float displayTime)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }
        messageCoroutine = StartCoroutine(DisplayMessage(message, displayTime));
    }

}
