using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;

    public PlayerCam playerCam;
    public Slider mouseSensitivitySlider;

    private void Start()
    {
        mouseSensitivitySlider.value = playerCam.mouseSensitivity;
        mouseSensitivitySlider.onValueChanged.AddListener(SetMouseSensitivity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;   // Stop game time
        pauseMenuCanvas.SetActive(true);  // Display the pause menu
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;   // Resume game time
        pauseMenuCanvas.SetActive(false);  // Hide the pause menu
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void SetMouseSensitivity(float sensitivity)
    {
        playerCam.SetSensitivity(sensitivity);
    }
}
