using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour
{
    public float throwForce; // force to apply to this bomb when thrown
    public float explosionRadius; // bomb explosion radius
    public float timer; // time the bomb explodes after been thrown
    public GameObject player; // the player in the scene
    public Transform holdPoint; // point where the player holds the bomb
    public ParticleSystem explosionEffect; // particle system to instantiate when exploding

    private Rigidbody2D rb; // rigidbody attached to this bomb
    private Vector2 throwForceV; // force vector passed to rb.AddForce()
    private AudioSource audioSource; // used to play sounds
    private SpriteRenderer renderer;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        throwForceV = new Vector2(player.transform.localScale.x * throwForce, throwForce);
    }

    /// <summary>
    /// Called when this bomb has been thrown, EXPLODEEEEE!
    /// </summary>
    void Throw()
    {
        StartCoroutine(TimedExplosion());
    }

    /// <summary>
    /// Called when this bomb is picked up by the player.
    /// </summary>
    void Pickup()
    {
        rb.isKinematic = true;
        transform.parent = holdPoint.transform;
        transform.position = holdPoint.position;
    }

    /// <summary>
    /// Handles all the explosion process.
    /// </summary>
    /// <returns></returns>
    IEnumerator TimedExplosion()
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(throwForceV, ForceMode2D.Impulse);
        yield return new WaitForSeconds(timer);
        foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, explosionRadius))
        {
            col.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
        }
        renderer.enabled = false;
        audioSource.Play();
        explosionEffect.Play();
        Destroy(gameObject, explosionEffect.duration);
    }
}
