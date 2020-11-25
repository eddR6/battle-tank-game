using UnityEngine;

public class ExplosionService : MonoSingletonGeneric<ExplosionService>
{
    [SerializeField]
    private ParticleSystem tankExplosion;
    [SerializeField]
    private ParticleSystem bulletExplosion;

    protected override void Awake()
    {
        base.Awake();
    }

    public ParticleSystem GetTankExplosion()
    {
        return Instantiate(tankExplosion, new Vector3(0, 15, 0), Quaternion.identity);
    }

    public ParticleSystem GetBulletExplosion()
    {
        return Instantiate(bulletExplosion, new Vector3(0, 25, 0), Quaternion.identity);
    }

}
