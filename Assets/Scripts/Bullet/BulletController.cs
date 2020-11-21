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
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (enemyController)
        {
            enemyController.TakeDamage(damage);
        }
        else if (playerController)
        {
            playerController.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
