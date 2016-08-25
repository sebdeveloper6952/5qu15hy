using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ganar2 : MonoBehaviour {

    public Text gameManagerText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Dog")
        {
            StartCoroutine(YouWin());
        }
    }

    IEnumerator YouWin()
    {
        gameManagerText.text = "You Win!";
        gameManagerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        gameManagerText.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
