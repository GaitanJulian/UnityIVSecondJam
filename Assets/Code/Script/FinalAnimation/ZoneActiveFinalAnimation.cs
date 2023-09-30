using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneActiveFinalAnimation : MonoBehaviour
{
    [Header("Player And FinalAnimation")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finalAnimation;



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            finalAnimation.SetActive(true);
            Invoke("LoadNextScene", 58f);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("FinalCredits");
    }
}

