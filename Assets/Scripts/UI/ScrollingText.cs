using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScrollingText : MonoBehaviour
{

    public GameObject text;
    public float scrollSpeed;
    public float outOfBounds;

    private Vector3 newPos;
    private Vector3 originalPos;
	
    // Use this for initialization
	void Start ()
    {
        originalPos = text.transform.position; // save original position
        newPos = originalPos;
        print(Screen.height);
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(text.transform.localPosition.y);
        if (text.transform.localPosition.y > outOfBounds)
        {
            ReturnToMainMenu();
        }
        Scroll();
	}

    /// <summary>
    /// Scroll the text game object.
    /// </summary>
    void Scroll()
    {
        newPos = new Vector3(newPos.x, newPos.y + scrollSpeed * Time.deltaTime, newPos.z);
        text.transform.position = newPos;
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
