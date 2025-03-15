using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapProjectile : MonoBehaviour
{
    [Tooltip("The speed multiplier of the projectile")]
    [SerializeField]
    private float speed = 0.05f;

    [Tooltip("Time until the projectile destroys itself")]
    [SerializeField]
    private float lifetime = 10.0f;

    private void Start()
    {
        //Start coroutine to destroy object after liftime
        StartCoroutine(DestroyAfterSeconds());
    }

    private void FixedUpdate()
    {
        //Move forward
        transform.position += transform.right * speed;
    }

    private IEnumerator DestroyAfterSeconds()
    {
        //Destroy the projectile after lifetime
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
