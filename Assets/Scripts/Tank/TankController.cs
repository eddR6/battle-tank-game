using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Joystick joystick;

    private float speed;
    private float rotationSpeed=150;
    private int health;
    private int attack;
    private TankColor tankColor;
    [SerializeField]
    private Transform muzzleTransform;

    public void SetBaseValues(TankScriptableObjects configs)
    {
        speed = configs.speed;
        health = configs.health;
        attack = configs.attack;
        tankColor = configs.tankColor;
        
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
        Debug.Log(vertical + " " + horizontal);
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
    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
