using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    [Header("Player Tank Object")]
    public GameObject playerTank;
    protected override void Awake()
    {
        base.Awake();
        TankService.Instance.GetTank();
    }

    public void GetTank()
    {
        Instantiate(playerTank, Vector3.zero, Quaternion.identity);
    }
}
