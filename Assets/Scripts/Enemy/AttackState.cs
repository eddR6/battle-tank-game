using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField]
    private Transform turretTransform;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private PatrolState patrolState;
    private bool canFireBullet;
    
    public override void OnStateEnter()
    {
        playerTransform = TankService.Instance.GetCurrentPlayer().transform;
        canFireBullet = true;
    }

    public override void Tick()
    {
        PositionTurret();
        //
        StateCheck();
    }

    private void PositionTurret()
    {
        if (playerTransform == null)
        {
            playerTransform = TankService.Instance.GetCurrentPlayer().transform;
        }
        Vector3 direction = playerTransform.position - turretTransform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        turretTransform.rotation = Quaternion.Lerp(turretTransform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (Mathf.Abs(Quaternion.Angle(turretTransform.rotation, rotation))<=15)
        {
            FireBullet();
        }
    }

    private void StateCheck()
    {
        Vector3 distance = playerTransform.position - transform.position;
        if (distance.magnitude > attackRange)
        {
            enemyController.SetState(patrolState);
        }
    }

    private void FireBullet()
    {
        if (canFireBullet)
        {
            enemyController.FireBullet();
            canFireBullet = false;
            StartCoroutine(EnableFire());

        }
    }

    IEnumerator EnableFire()
    {
        yield return new WaitForSeconds(1);
        canFireBullet = true;
    }
}
