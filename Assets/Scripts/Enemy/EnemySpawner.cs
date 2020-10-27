﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int currentSpawn;

    void Start()
    {
        currentSpawn = 0;
    }

    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            EnemyController enemyController=TankService.Instance.GetEnemyTank();
            enemyController.gameObject.transform.position = spawnPoints[currentSpawn].position;
            currentSpawn++;
        }
    }
}