using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SquishyHealthManager : MonoBehaviour
{
    public int lives; // number of lives the dog has
    public Transform spawnCeption; // the spawn point of the spawn point
    public Text livesText; // UI text to show lives left

    // Use this for initialization
    void Start()
    {
        livesText.text = "x " + this.lives; // TODO - this shouldn't be here.
    }
    
        
    /// <summary>
    /// decrease lives by 1, update the UI text that shows lives
    /// </summary>
     private void Die()
    {
        transform.parent = null;
        transform.position = spawnCeption.position;
        if (this.lives > 0)
        {
            Respawn();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Respawn()
    {
        PlayerGrabObject.instance.hasItem = false;
        PlayerGrabObject.instance.item = null;
        this.lives--;
        livesText.text = "x " + this.lives; // adjust the UI
    }
}
