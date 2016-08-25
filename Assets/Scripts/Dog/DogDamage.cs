using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DogDamage : MonoBehaviour
{

    public int lives; // number of lives the dog has
    public Transform spawnCeption; // the spawn point of the spawn point
    public Text livesText; // UI text to show lives left

    private Rigidbody2D rigidbody;
    private bool dead;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        livesText.text = "x " + this.lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
            Respawn();
        dead = false;
    }
    /// <summary>
    /// Called when a collider collides with this gameObject
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damage")
        {
            dead = true;
        }
    }

    /// <summary>
    /// decrease lives by 1, update the UI text that shows lives
    /// </summary>
    public void Respawn()
    {
        if (this.lives > 0)
        {
            CGrabberScript.grabbed = false; // the dog is no longer grabbed
            rigidbody.velocity = Vector2.zero; // zero the dogs' velocity
            this.transform.position = spawnCeption.position; // respawn dog in spawnCeption position
            this.lives--; // reduce dogs' lives by 1
        }
        livesText.text = "x " + this.lives; // adjust the UI
    }
}
