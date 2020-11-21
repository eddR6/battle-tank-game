using UnityEngine;

public class BulletManager : MonoSingletonGeneric<BulletManager>
{
    [SerializeField]
    private BulletController bulletModel;
    protected override void Awake()
    {
        base.Awake();
    }
    public BulletController LaunchBullet(Transform parentTransform)
    {
        BulletController bullet = Instantiate<BulletController>(bulletModel, parentTransform.position, parentTransform.rotation);
        return bullet;    
    }
}
