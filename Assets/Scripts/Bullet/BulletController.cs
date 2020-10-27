using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
        }
        else if (collision.gameObject.GetComponent<TankController>())
        {
            collision.gameObject.GetComponent<TankController>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
