using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text gameManagerText; // used to let know the player when he wins or loses
    public GameObject player; // the player in scene

    private SquishyHealthManager dog; // used to access the dogs damage system
    private PlayerController2D playerInput; // used to disable/enable player input
    private Rigidbody2D playerRB; // rigidbody attached to the player

	// Use this for initialization
	void Start ()
    {
        dog = FindObjectOfType<SquishyHealthManager>();
        playerInput = player.GetComponent<PlayerController2D>();
        playerRB = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dog.lives == 0)
        {
            StartCoroutine(YouLost());
        }
	}

    /// <summary>
    /// When dog runs out of lives, this resets the game.
    /// </summary>
    /// <returns></returns>
    IEnumerator YouLost()
    {
        gameManagerText.gameObject.SetActive(true);
        playerInput.enabled = false;
        playerRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        playerInput.enabled = true;
        gameManagerText.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
   
}
