using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Joystick joystick;

    public float speed;
    public float rotationSpeed=150;
    public int health;
    public int attack;
    public TankColor tankColor;

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
            BulletManager.Instance.LaunchBullet(transform, attack);
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
