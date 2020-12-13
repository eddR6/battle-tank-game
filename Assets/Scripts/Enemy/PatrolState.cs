using UnityEngine;

public class PatrolState : EnemyState
{
    [SerializeField]
    private float castRadius;
    [SerializeField]
    private float checkDistance;
    [SerializeField]
    private AttackState attackState;

    public override void OnStateEnter()
    {
        playerTransform = TankService.Instance.GetCurrentPlayer().transform;
    }
    public override void Tick()
    {
        Patrol();
        //
        StateCheck();
    }

    private void Patrol()
    {
        rb.velocity = (enemyController.GetSpeed() * 0.1f) * transform.forward;
        Ray ray = new Ray(transform.position, transform.forward);
        bool obstacle = Physics.SphereCast(ray, castRadius, checkDistance);
        if (obstacle)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    private void StateCheck()
    {
        if (playerTransform == null)
        {
            playerTransform = TankService.Instance.GetCurrentPlayer().transform;
        }
        Vector3 distance = playerTransform.position - transform.position;
        if (distance.magnitude <= attackRange)
        {
            enemyController.SetState(attackState);
        }
    }
}
