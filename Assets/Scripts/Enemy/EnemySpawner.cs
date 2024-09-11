using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
   public class Wave
    {
        public string Name;
        public List<EnemyGroup> enemyGroups;
        public int EnemiesSpawnLimitPerWave;
        public float spawnInterval;
        public float spawnCount;
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyname;
        public int enemyCount; 
        public int spawnCount;
        public GameObject enemies;
    }

    public List<Wave> waves;
    public int currentWaveCount;

    float spawnTimer;
    public float wavesInterval;
    public int enemiesAlive;
    public int enemiesAllowed;
    public bool enemiesBlocked;
    Transform player;

    public List<Transform> spawnPointsEnemys;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerStats>().transform;
        CalculateEnemiesSpawned();
        
    }

    private void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(NextWave());
        }
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(wavesInterval);
        if (currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateEnemiesSpawned();
        }
    }

    void CalculateEnemiesSpawned()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].EnemiesSpawnLimitPerWave =currentWaveQuota ;
    }

    void SpawnEnemies()
    {

        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].EnemiesSpawnLimitPerWave && !enemiesBlocked) 
        {
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if(enemiesAlive >= enemiesAllowed)
                    {
                        enemiesBlocked = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemies, player.position + spawnPointsEnemys[Random.Range(0, spawnPointsEnemys.Count)].position, Quaternion.identity);
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }

        if (enemiesAlive < enemiesAllowed)
        {
            enemiesBlocked  = false;
        }
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }
}
