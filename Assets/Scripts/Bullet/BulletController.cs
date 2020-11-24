using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public float speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable collider = collision.gameObject.GetComponent<IDamagable>();
        if (collider!=null)
        {
            collider.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    public void LaunchBullet()
    {
        rb.AddForce(transform.forward * speed);
    }
}
