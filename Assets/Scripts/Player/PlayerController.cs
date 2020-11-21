using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;

    private float speed;
    private float rotationSpeed=150;
    private int health;
    private int attack;
    private TankColor tankColor;
    [SerializeField]
    private Transform muzzleTransform;
    [SerializeField]
    private ParticleSystem tankExplosion;
    [SerializeField]
    private MeshRenderer[] meshes;
    [SerializeField]
    private GameObject tankRenderer;

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

    void Update()
    {
        Movement();
        FireBullet();
    }
    private void Movement()
    {
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;
       
        //float vertical = Input.GetAxis("Vertical");
       // float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log(vertical + " " + horizontal);
        transform.position = transform.position + transform.forward*speed * vertical * Time.deltaTime;
        transform.Rotate(Vector3.up*rotationSpeed*Time.deltaTime*horizontal);
    }
    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletController bulletController = BulletManager.Instance.LaunchBullet(muzzleTransform);
            bulletController.damage = attack;
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
    IEnumerator DeathEffect()
    {
        this.enabled = false;
        yield return new WaitForSeconds(tankExplosion.main.duration);
        TankService.Instance.RespawnPlayer(this);
    }
}
