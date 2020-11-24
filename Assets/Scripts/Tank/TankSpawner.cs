using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField]
    private float xLower;
    [SerializeField]
    private float xUpper;
    [SerializeField]
    private float zLower;
    [SerializeField]
    private float zUpper;

    public void RespawnTank(TankController tankController)
    {
        tankController.transform.position = GetSpawnPoint();
    }

    private Vector3 GetRandomPoint()
    {
        float x = Random.Range(xLower, xUpper);
        float z = Random.Range(zLower, zUpper);
        Vector3 point = new Vector3(x, 0, z);
        return point;
    }

    private Vector3 GetSpawnPoint()
    {
        while (true)
        {
            Vector3 point = GetRandomPoint();
            Collider[] colliders = Physics.OverlapSphere(point, 5f);
            if (colliders.Length <= 1)
            {
                return point;
            }
        }
    }
}
