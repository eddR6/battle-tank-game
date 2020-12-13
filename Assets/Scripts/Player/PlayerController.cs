using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TankController
{
    public Joystick joystick;

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
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
}
