using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{

    public float moveSpeed; // player moving speed
    public float jumpHeight; // player jumping height
    public Transform groundPoint; // point to detect if player is grounded
    public LayerMask groundMask; // what is ground?
    public GameObject dog; // Squishy!
    public AudioClip jumpSound; // jumping sound
    public AudioClip[] dieSounds; // array of different dying sounds
    public GameObject blood; // particle system for when the player dies

    private bool isGrounded; // player is grounded?
    private Rigidbody2D rigidbody; // rigidbody attached to player
    private Vector2 spawnPoint;
    private Vector2 moveDir;
    private AudioSource audioSource;
    private float randomPitch;
    private float originalPitch;
    private Vector3 groundCheckDistance;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        originalPitch = audioSource.pitch;
        groundCheckDistance = new Vector3(0f, 0.5f, 0f);
    }


    void Update()
    {
        // check if player is touching the ground
        isGrounded = Physics2D.Linecast(groundPoint.position, groundPoint.position - groundCheckDistance);

        // apply movement
        Move();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // make the player turn to match its moving direction
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = Vector3.one;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /// <summary>
    /// Handle player movement.
    /// </summary>
    private void Move()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigidbody.velocity.y);
        rigidbody.velocity = moveDir;
    }

    /// <summary>
    /// Make the player jump if it is grounded.
    /// </summary>
    private void Jump()
    {
        rigidbody.AddForce(new Vector2(0, jumpHeight));
        audioSource.clip = jumpSound;
        audioSource.pitch = Random.Range(originalPitch - 0.2f, originalPitch + 0.2f);
        audioSource.Play();
    }

    /// <summary>
    /// Handle the player death
    /// </summary>
    private void Die()
    {
        Instantiate(blood, transform.position, transform.rotation); // play blood particle system
        gameObject.SetActive(false);
        spawnPoint = new Vector2(dog.transform.position.x, dog.transform.position.y + 1);
        transform.position = spawnPoint;
        gameObject.SetActive(true);
        int i = Random.Range(0, dieSounds.Length); // choose a random sound
        audioSource.clip = dieSounds[i];
        audioSource.Play();
    }

    /// <summary>
    ///  Die if the player touches something tagged as Damage
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Damage" || other.tag == "Enemy")
        { 
            this.Die();
        }
    }
}