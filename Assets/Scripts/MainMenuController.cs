using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

     // Oyundan ��kar
    public void ExitGame()
    {
        Debug.Log("Oyun kapat�l�yor...");
        Application.Quit();
    }
}
