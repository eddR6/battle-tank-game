using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public float speed;
    private Rigidbody rb;
    int i = 0;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log( i);
        i++;
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
    public void LaunchBullet()
    {
        rb.AddForce(transform.forward * speed);
        Debug.Log("here" + i);
        i++;
    }
}
