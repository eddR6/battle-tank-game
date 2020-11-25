using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public float speed;
    [SerializeField]
    private float bulletTime;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private BoxCollider boxCollider;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private void Start()
    {
        StartCoroutine(BulletLifeTime());   
    }

    IEnumerator BulletLifeTime()
    {
        yield return new  WaitForSeconds(bulletTime);
        BulletExplosion();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable!=null)
        {
            damagable.TakeDamage(damage);
        }
        BulletExplosion();
    }

    private void BulletExplosion()
    {
        ParticleSystem explosion = ExplosionService.Instance.GetBulletExplosion();
        boxCollider.enabled = false;
        explosion.transform.position = gameObject.transform.position;
        explosion.Play();
        meshRenderer.enabled = false;
        StartCoroutine(CollisionEffect(explosion));
    }

    IEnumerator CollisionEffect(ParticleSystem explosion)
    {
        yield return new WaitForSeconds(explosion.main.duration);
        Destroy(explosion.gameObject);
        Destroy(gameObject);
    }

    public void LaunchBullet()
    {
        rb.AddForce(transform.forward * speed);
    }
}
