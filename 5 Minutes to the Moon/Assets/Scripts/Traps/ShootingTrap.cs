using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{

    public float shooting_cooldown = 2.5f;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shooting_cooldown);
            Debug.Log("Shoot");
        }
    }
}
