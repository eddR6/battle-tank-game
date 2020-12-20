using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action EnemyOnDeath;
    public static event Action BulletsFired;

    public static void InvokeEnemyOnDeath()
    {
        EnemyOnDeath?.Invoke();
    }

    public static void InvokeBulletsFired()
    {
        BulletsFired?.Invoke();
    }
}
