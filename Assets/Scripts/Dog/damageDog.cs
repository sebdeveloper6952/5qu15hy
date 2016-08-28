using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damageDog : MonoBehaviour {

    public int lives; // number of lives the dog has
    public Transform spawnCeption; // the spawn point of the spawn point
    public Text livesText; // UI text to show lives left
    bool damaged;

    // Use this for initialization
    void Start ()
    {
        livesText.text = "x " + this.lives;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (damaged)
            Respawn();
        damaged = false;
	}
    /// <summary>
    /// Called when a collider collides with this gameObject
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damage")
        {
            //lowerLives(); // lower lives if an enemy touches the dog
            damaged = true;
        }
    }

    /// <summary>
    /// decrease lives by 1, update the UI text that shows lives
    /// </summary>
    public void Respawn()
    {
        if (this.lives > 0)
        {
            CGrabberScript.grabbed = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            this.transform.position = spawnCeption.position;
            this.lives--;
        }
        livesText.text = "x " + this.lives;
    }
}
