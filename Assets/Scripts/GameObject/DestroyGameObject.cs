using UnityEngine;
using System.Collections;

public class DestroyGameObject : MonoBehaviour
{
    public float lifeTime;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
