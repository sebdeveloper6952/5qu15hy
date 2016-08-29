using UnityEngine;
using System.Collections;

public class Underworld : MonoBehaviour
{

    private PlayerController2D player;
    private SquishyDamage dog;
	
    void Start()
    {
        player = FindObjectOfType<PlayerController2D>();
        dog = FindObjectOfType<SquishyDamage>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.Die();
        }
        if (other.name == "Dog")
        {
            dog.Respawn();
        }
    }
}
