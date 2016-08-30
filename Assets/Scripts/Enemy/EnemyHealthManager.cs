using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    /// <summary>
    /// For now, the enemy gameObject is just destroyed
    /// </summary>
    private void Die()
    {
        Destroy(gameObject);
    }
}
