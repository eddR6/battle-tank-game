using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public Joystick joystick;

    [Header("Player Tank Object")]
    public GameObject playerTank;
    protected override void Awake()
    {
        base.Awake();
        TankService.Instance.GetTank();
    }

    public TankController GetTank()
    {
        Instantiate(playerTank, Vector3.zero, Quaternion.identity);
        TankController tankController = playerTank.GetComponent<TankController>();
        tankController.joystick = joystick;
        return tankController;
    }
}
