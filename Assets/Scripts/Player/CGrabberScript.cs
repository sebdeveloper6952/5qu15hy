using UnityEngine;
using System.Collections;

public class CGrabberScript : MonoBehaviour
{

    public static bool grabbed; // is the dog grabbed?
    public float distance; // maximum distance to grab the dog
    public float throwforce; // force to throw your dog
    public Transform holdpoint; // where the heroe holds the dog
    public LayerMask notgrabbed;
    public Transform rayPoint;
    public AudioClip tossSound;

    private float originalPitch;
    private RaycastHit2D hit; // hit info
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalPitch = audioSource.pitch;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(rayPoint.position, Vector2.right * transform.localScale.x, distance);
                if (hit.collider != null && hit.collider.tag == "Pickable")
                {
                    grabbed = true;
                }
                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;
                Rigidbody2D colliderRB = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (colliderRB != null)
                {
                    colliderRB.velocity = new Vector2(transform.localScale.x, 1f) * throwforce;
                    float randomTorque = Random.Range(-50f, 50f);
                    colliderRB.AddTorque(randomTorque, ForceMode2D.Impulse);
                    //audioSource.clip = tossSound;
                    //audioSource.pitch = Random.Range(originalPitch - 0.2f, originalPitch + 0.2f);
                    //audioSource.Play(); // play toss sound
                }
            }
        }
        if (grabbed)
        {
            hit.transform.position = holdpoint.position;
            hit.transform.rotation = Quaternion.identity;
        }
    }
}
