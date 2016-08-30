using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float movementSpeed;
    public Transform sightStart;
    public Transform sightEnd;
    public bool colliding;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        colliding = false;
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        rigidbody.velocity = new Vector2(movementSpeed, rigidbody.velocity.y);
        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position);
        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            movementSpeed *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Enemy")
        {
            other.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
        }
    }
}
