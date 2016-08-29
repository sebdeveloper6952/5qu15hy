using UnityEngine;
using System.Collections;

public class SquishyGrabManager : MonoBehaviour
{
    public float throwForce; // force to apply to this bomb when thrown
    public GameObject player; // the player in the scene
    public GameObject dog; // dog in scene
    public Transform holdpoint; // point where the player holds the bomb

    private Rigidbody2D rb; // rigidbody attached to this bomb
    private bool grabbed; // is this bomb grabbed?
    private bool thrown; // has this bomb been thrown already?
    private Vector2 throwForceV; // force vector passed to rb.AddForce()
    private SquishyDamage dogDamage; // used to respawn the dog if necessary
    private Vector3 grabbedPos;
    private Vector3 grabbedRot;


    

    // Use this for initialization
 //   void Start()
 //   {
 //       rb = GetComponent<Rigidbody2D>();
 //       grabbed = false;
 //       dogDamage = dog.GetComponent<SquishyDamage>();
 //       grabbedPos = new Vector3(0.3f, 0f, 0f);
 //       grabbedRot = new Vector3(0f, 0f, 45f);
 //   }

 //   void Update()
 //   {
 //       throwForceV = new Vector2(player.transform.localScale.x * throwForce, throwForce);
 //   }

 //   /// <summary>
 //   /// 
 //   /// </summary>
	//void FixedUpdate()
 //   {
 //       if (grabbed && Input.GetKeyUp(KeyCode.RightShift) && !thrown)
 //       {
 //           rb.isKinematic = false;
 //           rb.AddForce(throwForceV, ForceMode2D.Impulse);
 //           transform.parent = null;
 //           grabbed = false;
 //           thrown = true;
 //           StartCoroutine(ThrownProcedure());
 //       }
 //   }
    
 //   /// <summary>
 //   /// Reset the thrown variable after some time, so the player can pick up the dog again
 //   /// </summary>
 //   /// <returns></returns>
 //   IEnumerator ThrownProcedure()
 //   {
 //       yield return new WaitForSeconds(0.1f);
 //       thrown = false;
 //   }

 //   /// <summary>
 //   /// 
 //   /// </summary>
 //   /// <param name="other"></param>
 //   void OnTriggerStay2D(Collider2D other)
 //   {
 //       if (!grabbed && other.name == "Player" && !thrown)
 //       {
 //           if (Input.GetKeyUp(KeyCode.RightShift))
 //           {
 //               rb.isKinematic = true;
 //               grabbed = true;
 //               transform.parent = holdpoint.transform;
 //               transform.localScale *= player.transform.localScale.x;
 //               transform.position = holdpoint.transform.position + grabbedPos;
 //               transform.rotation = Quaternion.Euler(grabbedRot);
 //           }
 //       }
 //   }
}
