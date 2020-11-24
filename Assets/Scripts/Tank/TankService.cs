using System.Linq;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public Joystick joystick;
    [SerializeField]
    private TankConfigurations friendlyTanks;
    [SerializeField]
    private TankConfigurations enemyTanks;
    [SerializeField]
    private CameraController mainCamera;
    [SerializeField]
    private TankSpawner tankSpawner;

    [Header("Player Tank Object")]
    [SerializeField]
    private PlayerController friendlyTankModel;
    [SerializeField]
    private EnemyController enemyTankModel;

    protected override void Awake()
    {
        base.Awake();
        //
        PlayerController tc=TankService.Instance.GetFriendlyTank();
        foreach(int x in Enumerable.Range(0, 5))
        {
            EnemyController enemy = GetEnemyTank();
            tankSpawner.RespawnTank(enemy);
        }
        
       
    }

    public PlayerController GetFriendlyTank()
    {
        PlayerController playerController = Instantiate<PlayerController>(friendlyTankModel, new Vector3(0,10,0), Quaternion.identity);
        playerController.joystick = joystick;
        mainCamera.target = playerController;
        playerController.SetBaseValues(friendlyTanks.tankConfigurations[0]);
        return playerController;

    }
    public EnemyController GetEnemyTank()
    {
        //Returning random enemy tank for now
        EnemyController enemyController = Instantiate<EnemyController>(enemyTankModel, Vector3.zero, Quaternion.identity);
        int tankType = Random.Range(0,enemyTanks.tankConfigurations.Length-1);
        enemyController.SetBaseValues(enemyTanks.tankConfigurations[tankType]);
        return enemyController;
    }
    
    public PlayerController RespawnTank(PlayerController playerController)
    {
        Destroy(playerController.gameObject);
        PlayerController newTank = GetFriendlyTank();
        tankSpawner.RespawnTank(newTank);
        return playerController;
    }

    public EnemyController RespawnTank(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        EnemyController newTank = GetEnemyTank();
        tankSpawner.RespawnTank(newTank);
        return enemy;
    }
}
