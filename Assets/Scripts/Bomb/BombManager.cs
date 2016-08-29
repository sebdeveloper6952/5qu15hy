using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour
{
    public float throwForce; // force to apply to this bomb when thrown
    public float explosionRadius; // bomb explosion radius
    public float timer; // time the bomb explodes after been thrown
    public GameObject player; // the player in the scene
    public GameObject dog; // dog in scene
    public Transform holdPoint; // point where the player holds the bomb

    private Rigidbody2D rb; // rigidbody attached to this bomb
    private bool grabbed; // is this bomb grabbed?
    private bool thrown; // has this bomb been thrown already?
    private Vector2 throwForceV; // force vector passed to rb.AddForce()
    private SquishyDamage dogDamage; // used to respawn the dog if necessary


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grabbed = false;
        dogDamage = dog.GetComponent<SquishyDamage>();
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
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(throwForceV, ForceMode2D.Impulse);
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
}
