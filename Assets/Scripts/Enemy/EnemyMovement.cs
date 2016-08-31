using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float movementSpeed;
    public Transform sightStart;
    public Transform sightEnd;
    private bool touchingWall; // used to turn around the enemy
    private bool colliding; // used to detect collisions with gameObjects the enemy can kill

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        touchingWall = false;
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
        touchingWall = Physics2D.Linecast(sightStart.position, sightEnd.position);
        if (touchingWall)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            movementSpeed *= -1;
        }
        colliding = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Enemy" && !colliding)
        {
            colliding = true;
            other.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
        }
    }
}
