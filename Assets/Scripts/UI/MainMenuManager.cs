using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{

    /// <summary>
    /// Load the main menu.
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Load the first level.
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Display instructions and objective of the game.
    /// </summary>
    public void Instructions()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 
    /// </summary>
    public void About()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Exit to desktop.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
