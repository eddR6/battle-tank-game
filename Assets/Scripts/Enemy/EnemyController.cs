using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed;
    private float rotationSpeed;
    private int health;
    private int attack;
    private TankColor tankColor;
    [Header("Renderer Parts")]
    [SerializeField]
    private MeshRenderer[] meshes;

    public void SetBaseValues(TankScriptableObjects configs)
    {
        speed = configs.speed;
        health = configs.health;
        attack = configs.attack;
        tankColor = configs.tankColor;
        
        foreach (MeshRenderer mesh in meshes)
        {
            if (tankColor == TankColor.Blue)
            {
                mesh.material.color = Color.blue;
            }
            else if (tankColor == TankColor.Red)
            {
                mesh.material.color = Color.red;
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(100);
        }
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            TankService.Instance.RespawnEnemy(this);
        }
    }
}
