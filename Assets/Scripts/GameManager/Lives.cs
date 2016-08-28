using UnityEngine;
using System.Collections;
using UnityEngine.UI;

   public class Lives : MonoBehaviour
{

    public GameObject dog;
    public Transform spawnCeption;
    public Text livesText;

    public static int lives;

    // Use this for initialization
    void Start()
    {
        lives = 5;
        livesText.text = "x" + lives;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void  lowerLives()
    {
        lives--;
        dog.transform.position = spawnCeption.position;
        livesText.text = "x" + lives;
    }

}
