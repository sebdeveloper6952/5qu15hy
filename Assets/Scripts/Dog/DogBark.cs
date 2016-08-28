using UnityEngine;
using System.Collections;

public class DogBark : MonoBehaviour {

    AudioSource Source;
    bool grabbed;

    // Use this for initialization
    void Start () {
        Source = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        grabbed = CGrabberScript.grabbed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (grabbed)
            {
                Source.Play();
            }
            else
                Source.Stop();
        }
	}
}
