using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject player; // the player
    public GameObject pauseMenu; // the pause menu game object

    private PlayerController2D playerInput; // used to control enable / disable player input
    private bool active; // is the pause menu active?

    // Use this for initialization
    void Start ()
    {
        active = pauseMenu.activeSelf;
        playerInput = player.GetComponent<PlayerController2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
        {
            active = !active;
            if (active)
                PauseGame();
            else
                UnPauseGame();
            pauseMenu.SetActive(active);
        }
	}

    /// <summary>
    /// Exit to desktop.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Disable player input and freeze the game time.
    /// </summary>
    public void PauseGame()
    {
        playerInput.enabled = false;
        Time.timeScale = 0.0f;
    }

    /// <summary>
    ///  Enable player input and resume game time.
    /// </summary>
    public void UnPauseGame()
    {
        playerInput.enabled = true;
        Time.timeScale = 1.0f;
    }
}
