using UnityEngine;
using System.Collections;

public class Underworld : MonoBehaviour
{

    private PlayerController2D player;
    private SquishyHealthManager dog;
	
    void Start()
    {
        player = FindObjectOfType<PlayerController2D>();
        dog = FindObjectOfType<SquishyHealthManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
    }
}
