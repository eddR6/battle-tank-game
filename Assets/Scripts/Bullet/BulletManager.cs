using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoSingletonGeneric<BulletManager>
{
    public BulletController bulletModel;
    protected override void Awake()
    {
        base.Awake();
    }
    public void LaunchBullet(Transform parentTransform,int damage)
    {
        BulletController bullet = Instantiate<BulletController>(bulletModel, parentTransform.position+new Vector3(0,1,2), parentTransform.rotation);
        bullet.damage = damage;
        Rigidbody rb = bullet.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(parentTransform.forward*200);
    }
    
}
