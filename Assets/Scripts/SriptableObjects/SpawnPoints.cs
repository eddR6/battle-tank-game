using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Points", menuName = "ScriptableObjects/Spawn Points")]
public class SpawnPoints : ScriptableObject
{
    public Vector3[] vectorPoints;
}