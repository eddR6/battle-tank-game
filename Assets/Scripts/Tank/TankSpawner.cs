using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public GameObject hh;
    public LayerMask layer;
    public float chd;
    [SerializeField]
    private SpawnPoints spawnPointsArray;
    private static SpawnPoints spawnPoints;
    private void Start()
    {
        spawnPoints = spawnPointsArray;
    }

    public static void RespawnTank(TankController tankController)
    {
       foreach(Vector3 point in spawnPoints.vectorPoints)
        {
            Collider[] colliders = Physics.OverlapSphere(point, 5f);
            bool hasEnemy = false;
            foreach (Collider collider in colliders)
            {
                if (collider.transform.gameObject.GetComponent<EnemyController>()!=null)
                {
                    hasEnemy = true;
                    break;
                }
            }
            if (!hasEnemy)
            {
                tankController.transform.position = point;
                tankController.ToggleMesh(true);
                break;
            }
        }
    }
    
}
