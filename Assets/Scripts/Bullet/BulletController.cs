using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public float speed;

    private void Start()
    {
        Rigidbody rb =gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
        TankController tankController = collision.gameObject.GetComponent<TankController>();
        if (enemyController)
        {
            enemyController.TakeDamage(damage);
        }
        else if (tankController)
        {
            tankController.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
