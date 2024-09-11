using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Scriptable Objects/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    float movespeed;
    public float Movespeed { get => movespeed; private set => movespeed = value; }
    [SerializeField]
    float hp;
    public float HP { get => hp; private set => hp = value; }
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }
}
