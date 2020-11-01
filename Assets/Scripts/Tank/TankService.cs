using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : MonoSingletonGeneric<TankService>
{
    public Joystick joystick;
    [SerializeField]
    private TankConfigurations friendlyTanks;
    [SerializeField]
    private TankConfigurations enemyTanks;

    [Header("Player Tank Object")]
    [SerializeField]
    private TankController friendlyTankModel;
    [SerializeField]
    private EnemyController enemyTankModel;

    protected override void Awake()
    {
        base.Awake();
        //
        TankController tc=TankService.Instance.GetFriendlyTank();
        
       
    }

    public TankController GetFriendlyTank()
    {
        TankController tankController = Instantiate<TankController>(friendlyTankModel, Vector3.zero, Quaternion.identity);
        tankController.joystick = joystick;
        tankController.SetBaseValues(friendlyTanks.tankConfigurations[0]);
        return tankController;

    }
    public EnemyController GetEnemyTank()
    {
        //Returning random enemy tank for now
        EnemyController enemyController = Instantiate<EnemyController>(enemyTankModel, Vector3.zero, Quaternion.identity);
        int tankType = Random.Range(0,enemyTanks.tankConfigurations.Length-1);
        enemyController.SetBaseValues(enemyTanks.tankConfigurations[tankType]);
        return enemyController;
    }
}
