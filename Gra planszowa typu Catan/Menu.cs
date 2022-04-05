using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject rulesWindow;
    
    public string game;

    public void LoadGame()
    {
        SceneManager.LoadScene(game);
    }

    public void ShowRules()
    {
        rulesWindow.SetActive(true);
    }

    public void HideRules()
    {
        rulesWindow.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
