using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    private int enemiesKilled;
    private int bulletsFired;

    private void Start()
    {
        enemiesKilled = 0;
        bulletsFired = 0;
        GameEvents.BulletsFired += UpdateBulletsFired;
        GameEvents.EnemyOnDeath += UpdateEnemiesKilled;
    }

    private void UpdateEnemiesKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == 10)
        {
            Toast.Instance.Show("Achievement: Killed 10 Enemies!!", 2f, Toast.ToastColor.Blue);
        }
    }

    private void UpdateBulletsFired()
    {
        bulletsFired++;
        if (bulletsFired == 20)
        {
            Toast.Instance.Show("Achievement: Fired 20 Bullets!!", 2f, Toast.ToastColor.Blue);
        }
    }
}
