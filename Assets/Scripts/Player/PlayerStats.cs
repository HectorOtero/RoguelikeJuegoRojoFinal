using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerScriptable PlayerData;

    float currentHealth;
    float currentMoveSpeed;
    float currentRecovery;
    float currentMight;
    float currentProjectileSpeed;

    public ParticleSystem damageeffect;

    public int experience = 0;
    public int level = 1;
    public int experienceLimit;

    public GameManager gamemanager;

    [System.Serializable]

    public class LevelRange
    {
        public int startlevel;
        public int endlevel;
        public int experienceLimitIncrease;
    }

    public float invincibiliyDuration;
    float invicibilityTimer;
    bool isInvincible;

    public List<LevelRange> levels;

    private void Awake()
    {
        currentHealth = PlayerData.HP;
        currentMoveSpeed = PlayerData.MoveSpeed;
        currentRecovery = PlayerData.Recovery;
        currentMight = PlayerData.Might;
        currentProjectileSpeed = PlayerData.ProjectileSpeed;
    }

    private void Start()
    {
        experienceLimit = levels[0].experienceLimitIncrease;
        gamemanager = GetComponent<GameManager>();
    }

    private void Update()
    {
        if(invicibilityTimer > 0)
        {
            invicibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUp();
    }

    public void LevelUp()
    {
        if(experience >= experienceLimit)
        {
            level++;
            experience -= experienceLimit;

            int experienceLimitIncrease = 0;
            foreach(LevelRange levelRange in levels)
            {
                if (level >= levelRange.startlevel && level <= levelRange.endlevel)
                {
                    experienceLimitIncrease = levelRange.experienceLimitIncrease;
                    break;
                }
            }
            experienceLimit += experienceLimitIncrease;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;

            if (damageeffect) Instantiate(damageeffect, transform.position, Quaternion.identity);

            invicibilityTimer = invincibiliyDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
        
    }
    
    public void Kill()
    {
        if(!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();          
            Time.timeScale = 0;
        }
    }
}
