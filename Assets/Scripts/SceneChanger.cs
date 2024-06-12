using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level-1");
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetAll();
        }
    }
    public void Quit()
    {
        Debug.Log("Application Shut Down...");
        Application.Quit();
    }
    public void LoadEndScreen()
    {
        SceneManager.LoadScene("End Screen");
    }
    public void LoadMainMenu()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.HideUI();
        }
        SceneManager.LoadScene("Main Menu");
    }
}
