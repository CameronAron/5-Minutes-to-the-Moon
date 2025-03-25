using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    private enum DIRECTION
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    [Tooltip("The amount of time between shots.")]
    [SerializeField]
    private float cooldown = 2.5f;

    [Tooltip("The direction that the projectiles will be shot.")]
    [SerializeField]
    private DIRECTION direction = 0;

    [Tooltip("The GameObject spawned when the trap shoots.")]
    [SerializeField]
    private GameObject projectile;

    private void Start()
    {
        //Begin the shooting coroutine
        StartCoroutine(Shooting());
    }

    //Coroutine that handles shooting
    private IEnumerator Shooting()
    {
        //Enter shooting loop
        while (true)
        {
            //Wait for the amount of time determined by ShootingCooldown
            yield return new WaitForSeconds(cooldown);
            //Shoot
            Shoot();
        }
    }

    //Called when the trap needs to shoot
    private void Shoot()
    {
        //Direction to shoot the projectile
        Vector2 projectileDirection;
        //Set ProjectileDirection based on Direction
        switch (direction)
        {
            case DIRECTION.Up:
                projectileDirection = Vector2.right;
                break;
            case DIRECTION.Down:
                projectileDirection = Vector2.left;
                break;
            case DIRECTION.Left:
                projectileDirection = Vector2.down;
                break;
            case DIRECTION.Right:
                projectileDirection = Vector2.up;
                break;
            default:
                projectileDirection = Vector2.up;
                break;
        }

        //Instantiate projectile
        GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        //Set projectile rotation to our desired direction
        newProjectile.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(projectileDirection.x, projectileDirection.y) * Mathf.Rad2Deg, Vector3.forward);
    }
}
