using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneActiveFinalAnimation : MonoBehaviour
{
    [Header("Player And FinalAnimation")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finalAnimation;

    public GameObject HUD;

    public void ActivateAnimation()
    {
        player.SetActive(false);
        finalAnimation.SetActive(true);
        HUD.SetActive(false);
        Invoke("LoadNextScene", 58f);
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene("FinalCredits");
    }
}

