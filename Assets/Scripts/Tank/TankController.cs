using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour,IDamagable
{
    protected float speed;
    protected float rotationSpeed=150f;
    protected int health;
    protected int attack;
    protected TankColor tankColor;
    //
    [SerializeField]
    protected Transform muzzleTransform;
    //
    [SerializeField]
    protected ParticleSystem tankExplosion;
    //
    [Header("Renderer Parts")]
    [SerializeField]
    protected MeshRenderer[] meshes;
    [SerializeField]
    protected GameObject tankRenderer;

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

    public void ToggleMesh(bool toggle)
    {
        tankRenderer.SetActive(toggle);
    }

    IEnumerator DeathEffect()
    {
        this.enabled = false;
        yield return new WaitForSeconds(tankExplosion.main.duration);
        TankService.Instance.RespawnTank(this);
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

    protected void FireBullet()
    {
        BulletController bulletController = BulletManager.Instance.GetBullet();
        bulletController.damage = attack;
        bulletController.transform.position = muzzleTransform.position;
        bulletController.transform.rotation = muzzleTransform.rotation;
        bulletController.LaunchBullet();
    }
}
