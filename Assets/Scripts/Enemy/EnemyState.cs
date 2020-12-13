using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField]
    protected EnemyController enemyController;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected float attackRange;
    protected Transform playerTransform;

    public abstract void Tick();

    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

}
