using UnityEngine;

public class BulletManager : MonoSingletonGeneric<BulletManager>
{
    [SerializeField]
    private BulletController bulletModel;
    [SerializeField]
    private Vector3 defaultBulletSpawn;
    protected override void Awake()
    {
        base.Awake();
    }
    public BulletController GetBullet()
    {
        BulletController bullet = Instantiate<BulletController>(bulletModel,defaultBulletSpawn, Quaternion.identity);
        return bullet;    
    }
}
