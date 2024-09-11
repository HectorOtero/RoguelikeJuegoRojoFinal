using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedknife = Instantiate(weaponData.Prefabweapon);
        spawnedknife.transform.position = transform.position;
        spawnedknife.GetComponent<Knifebehaviour>().DirectionChecker(pm.lastVector);
    }
}
