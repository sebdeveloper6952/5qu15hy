using UnityEngine;
using System.Collections;

public class SquishyGrabManager : MonoBehaviour
{
    public float throwForce; // force to apply to Squishy when thrown
    public GameObject player; // the player in the scene
    public GameObject dog; // dog in scene
    public Transform holdPoint; // point where the player holds Squishy

    private Rigidbody2D rb; // rigidbody attached to Squishy
    private Vector2 throwForceV; // force vector passed to rb.AddForce()

    
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        throwForceV = new Vector2(player.transform.localScale.x * throwForce, throwForce);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Pickup()
    {
        rb.isKinematic = true;
        transform.parent = holdPoint.transform;
        transform.position = holdPoint.position;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Throw()
    {
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(throwForceV, ForceMode2D.Impulse);
    }
}
