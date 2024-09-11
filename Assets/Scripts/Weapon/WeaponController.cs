using UnityEngine;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour
{
    public WeaponScriptable weaponData;
    float currentCooldown;
    protected PlayerMovement pm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        pm = FindFirstObjectByType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown < 0 )
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
