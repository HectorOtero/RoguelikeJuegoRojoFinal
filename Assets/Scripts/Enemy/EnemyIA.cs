using UnityEngine;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform Player;
    Vector2 knockbackVelocity;
    float knockbackDuration;
    
    void Start()
    {
        Player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(knockbackDuration > 0)
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockbackDuration -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemyData.Movespeed * Time.deltaTime);
        }
        
    }

    public void Knockback(Vector2 velocity, float duration)
    {
        if (knockbackDuration > 0) return;

        knockbackDuration = duration;
        knockbackVelocity = velocity;
    }
}
