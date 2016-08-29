using UnityEngine;
using System.Collections;

public class PlayerGrabObject : MonoBehaviour
{
    public Transform lineCastPoint;
    public Transform itemHoldPoint;
    GameObject item;
    Rigidbody2D grabbedItemRb;
    bool hasItem;
    bool justThrown;

	// Use this for initialization
	void Start ()
    {
        item = null; // player starts with no item 
        hasItem = false; // player starts with no item
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.RightShift))
        {
            if (!hasItem) // the player has no item, grab it!
            {
                PickupItem();
            }
            else // the player has an item, throw it!
            {
                StartCoroutine(ThrowItem());
            }
        }
	}

    /// <summary>
    /// Call the Throw method on the grabbed item, wait some time and let know the player
    /// he has no item on his possesion.
    /// </summary>
    /// <returns></returns>
    IEnumerator ThrowItem()
    {
        item.SendMessage("Throw", SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(0.1f);
        hasItem = false;
        item = null;
    }

    /// <summary>
    /// Picks up the item.
    /// </summary>
    private void PickupItem()
    {
        RaycastHit2D hitInfo = Physics2D.Linecast(lineCastPoint.position, lineCastPoint.position + new Vector3(1f, 0f, 0f));
        if (hitInfo.rigidbody != null) // TODO - add more validation
        {
            item = hitInfo.collider.gameObject;
            item.SendMessage("Pickup", SendMessageOptions.DontRequireReceiver);
            hasItem = true;
        }
    }
}
