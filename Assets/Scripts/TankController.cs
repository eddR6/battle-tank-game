using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    [Header("Joystick Prefab")]
    public Joystick joystick;

    public float speed;
    public float rotationSpeed;
    void Start()
    {
        joystick = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();   
    }
    void Update()
    {
        Movement();    
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
}
