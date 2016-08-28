using UnityEngine;
using System.Collections;

public class GrabStuff : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform holdpoint;
    bool grabbed;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(grabbed)
        {
            transform.position = holdpoint.position;
            if(Input.GetKeyUp(KeyCode.RightShift))
            {
                grabbed = false;
                rb.AddForce(new Vector2(5f, 5f));
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            grabbed = true;
        }
    }
}
