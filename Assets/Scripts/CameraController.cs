using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public PlayerController target;
    [SerializeField]
    private Vector3 offset;

    private void LateUpdate()
    {
        if (target != null)
        {
            float x = target.transform.position.x;
            float z = target.transform.position.z;
            transform.position = new Vector3(x, transform.position.y, z) + offset;
        }
    }
}
