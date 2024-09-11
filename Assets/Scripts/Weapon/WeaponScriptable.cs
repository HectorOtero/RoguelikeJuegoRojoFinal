using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptable", menuName = "Scriptable Objects/WeaponScriptable")]
public class WeaponScriptable : ScriptableObject
{
    [SerializeField]
    GameObject prefabweapon;
    public GameObject Prefabweapon { get => prefabweapon; private set => prefabweapon = value; }
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }
    [SerializeField]
    float speed;
    public float Speed { get =>  speed; private set => speed = value; }
    [SerializeField]
    float cooldownduration;
    public float CooldownDuration { get => cooldownduration; private set => cooldownduration = value; }
    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; } 

}
