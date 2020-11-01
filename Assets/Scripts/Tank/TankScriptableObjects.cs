using UnityEngine;

[CreateAssetMenu(fileName ="Tank Scriptable Object",menuName ="ScriptableObjects/Tank Object")]
public class TankScriptableObjects : ScriptableObject
{
    public TankColor tankColor;
    public float speed;
    public int health;
    public int attack;
}
