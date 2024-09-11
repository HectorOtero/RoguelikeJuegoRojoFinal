using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptable", menuName = "Scriptable Objects/PlayerScriptable")]
public class PlayerScriptable : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;

    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField]
    float hp;

    public float HP { get => hp; private set => hp = value; }

    [SerializeField]
    float recovery;

    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    float movespeed;

    public float MoveSpeed { get => movespeed; private set => movespeed = value; }

    [SerializeField]
    float might;

    public float Might { get => might; private set => might = value; }

    [SerializeField]
    float projectilSpeed;

    public float ProjectileSpeed { get => projectilSpeed; private set => projectilSpeed = value; }



}
