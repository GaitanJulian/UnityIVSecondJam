using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject interactPanel; // Reference to the interact UI element
    public GameObject messagePanel; // Reference to the message Panel
    public TextMeshProUGUI messageText;

    // lose Panel
    public GameObject losePanel;
    public Image darkScreen;
    public GameObject loseText;

    // Screamer Panel
    public GameObject screamerPanel;
    public Image screamer;

    private Coroutine screamerCoroutine;

    // Singleton instance
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private PlayerInteraction playerInteraction;

    private Coroutine messageCoroutine; // Coroutine for displaying messages
    
    private AudioManager audioManager;

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

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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

    // Method to handle game over
    public void HandleGameOver()
    {
        StartCoroutine(ShowGameOverOverlay());
    }

    private IEnumerator ShowGameOverOverlay()
    {
        // Activate the lose canvas
        losePanel.SetActive(true);

        // Smoothly transition the alpha of the dark screen image
        float duration = 2.0f;
        float startTime = Time.time;
        Color startColor = darkScreen.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            darkScreen.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        darkScreen.color = targetColor; // Ensure the final alpha value

        yield return new WaitForSeconds(1.5f);
        TriggerScreamer();
        PlayerInventory.ResetKeys();
        Invoke("GoToMainMenu", 3f);
    }

    // Coroutine to show the screamer
    // Method to trigger the screamer
    public void TriggerScreamer()
    {
        // Activate the screamer panel
        screamerPanel.SetActive(true);

        // Play the scream sound effect
        audioManager.PlaySoundEffect(audioManager.scream);

        // Quickly fade in
        screamer.DOFade(1.0f, 0.1f)
            .OnComplete(() => StartCoroutine(FadeOutScreamer()));
    }

    private IEnumerator FadeOutScreamer()
    {

        // Slowly fade out
        screamer.DOFade(0.0f, 1.0f)
            .OnComplete(() => DeactivateScreamer());

        yield return null;
    }

    private void DeactivateScreamer()
    {
        // Deactivate the screamer panel
        screamerPanel.SetActive(false);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
