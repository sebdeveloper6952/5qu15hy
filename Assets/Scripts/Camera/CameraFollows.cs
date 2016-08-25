using UnityEngine;
using System.Collections;

public class CameraFollows : MonoBehaviour {

    public float camSpeed; // pretty obvious
    public Transform target; // gameObject the camera follows

    private Vector3 adjustVector; // used to adjust the position of the camera, mainly in the z-axis

    void Start()
    {
        adjustVector = new Vector3(0, 0.25f, -10);
    }
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, camSpeed) + adjustVector;
	}
}
