using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float CurrentHealth;
    [HideInInspector]
    public float CurrentDamage;

    public float despawnDistance = 20f;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Color damageColor = new Color(1, 0, 0, 1);
    public float damageFlashDuration = 0.2f;
    public float deathFadeTime = 0.6f;
    Color OriginalColor;
    SpriteRenderer spriteRenderer;
    EnemyIA movement;

    private void Awake()
    {
        currentMoveSpeed = enemyData.Movespeed;
        CurrentHealth = enemyData.HP;
        CurrentDamage = enemyData.Damage;
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OriginalColor = spriteRenderer.color;
        player = FindAnyObjectByType<PlayerStats>().transform;

        movement = GetComponent<EnemyIA>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }

    public void TakeDamage(float dmg, Vector2 sourcePosition, float knockbackForce = 5f, float knockbackDuration = 0.2f)
    {
        CurrentHealth -= dmg;
        StartCoroutine(DmgFlash());

        if(knockbackForce > 0)
        {
            Vector2 dir = (Vector2)transform.position - sourcePosition;
            movement.Knockback(dir.normalized * knockbackForce, knockbackDuration);
        }

        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    IEnumerator DmgFlash()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        spriteRenderer.color = OriginalColor;
    }

    public void Kill()
    {
        StartCoroutine(KillFade());
    }

    IEnumerator KillFade()
    {
        WaitForEndOfFrame w = new WaitForEndOfFrame();
        float t = 0, orig = spriteRenderer.color.a;

        while (t < deathFadeTime)
        {
            yield return w;
            t += Time.deltaTime;

            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, (1 - t / deathFadeTime) * orig);

        }

        Destroy(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(CurrentDamage);
        }
    }

    private void OnDestroy()
    {
        EnemySpawner es = FindAnyObjectByType<EnemySpawner>();
        es.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindAnyObjectByType<EnemySpawner>();
        transform.position = player.position + es.spawnPointsEnemys[Random.Range(0, es.spawnPointsEnemys.Count)].position;
    }
}
