using UnityEngine;
using System.Collections;

public class DogAudio : MonoBehaviour
{

    private AudioSource source;
    private bool grabbed;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        grabbed = CGrabberScript.grabbed; // check if the dog is grabbed
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (grabbed)
            {
                source.Play();
            }
            else
                source.Stop();
        }
    }
}
