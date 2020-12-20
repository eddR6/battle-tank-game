using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    private EnemyState currentState;

    [SerializeField]
    private PatrolState patrolState;
    [SerializeField]
    private AttackState attackState;

    public void SetState(EnemyState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    private void Start()
    {
        SetState(patrolState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FireBullet();
        }
        //
        currentState.Tick();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(100);
        }
    }

    private void OnDestroy()
    {
        GameEvents.InvokeEnemyOnDeath();
    }

}
