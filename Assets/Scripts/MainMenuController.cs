using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
     // Oyundan çýkar
    public void ExitGame()
    {
        Debug.Log("Oyun kapatýlýyor...");
        Application.Quit();
    }
}
