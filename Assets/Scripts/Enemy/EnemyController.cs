using System.Collections;
using UnityEngine;

public class EnemyController : TankController
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FireBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(100);
        }
    }

}
