using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GV;
    [SerializeField] GameObject Asylum;
    [SerializeField] GameObject camera;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            //camera.SetActive(true);
            //SleepGameObjects();
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
    private void SleepGameObjects()
    {
        Player.SetActive(false);
        GV.SetActive(false);
        Asylum.SetActive(false);
    }
}
