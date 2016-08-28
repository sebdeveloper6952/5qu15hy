using UnityEngine;
using System.Collections;

public class BloodParticleSystem : MonoBehaviour
{
    public float duration;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, duration);
	}
}
