using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed;
    private float rotationSpeed;
    private int health;
    private int attack;
    private TankColor tankColor;
    [SerializeField]
    private Transform muzzleTransform;
    [SerializeField]
    private ParticleSystem tankExplosion;
    [Header("Renderer Parts")]
    [SerializeField]
    private MeshRenderer[] meshes;
    [SerializeField]
    private GameObject tankRenderer;

    private void Update()
    {
        FireBullet();
    }
    public void SetBaseValues(TankScriptableObjects configs)
    {
        speed = configs.speed;
        health = configs.health;
        attack = configs.attack;
        tankColor = configs.tankColor;
        
        foreach (MeshRenderer mesh in meshes)
        {
            if (tankColor == TankColor.Blue)
            {
                mesh.material.color = Color.blue;
            }
            else if (tankColor == TankColor.Red)
            {
                mesh.material.color = Color.red;
            }

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

    public void ToggleMesh(bool toggle)
    {
        tankRenderer.SetActive(toggle);
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            ToggleMesh(false);
            tankExplosion.Play();
            StartCoroutine(DeathEffect());
        }
    }
    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BulletController bulletController = BulletManager.Instance.GetBullet();
            bulletController.damage = attack;
            bulletController.transform.position = muzzleTransform.position;
            bulletController.transform.rotation = muzzleTransform.rotation;
            bulletController.LaunchBullet();
        }
    }

    IEnumerator DeathEffect()
    {
        this.enabled = false;
        yield return new WaitForSeconds(tankExplosion.main.duration);
        TankService.Instance.RespawnTank(this);
    }
}
