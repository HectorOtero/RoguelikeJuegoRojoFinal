using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public WeaponScriptable weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;


    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;


    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    void Update()
    {
        
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotate = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left
        {
            rotate.z = -270;
        }
        if (dirx == 0 && diry < 0) //down
        {
            rotate.z = -180;
        }
        if (dirx == 0 && diry > 0) //up
        {
            rotate.z = 0;
        }
        if (dirx > 0 && diry > 0) //Right up
        {
            rotate.z = -45;
        }
        if (dirx < 0 && diry > 0) //Left up
        {
            rotate.z = 45;
        }
        if (dirx < 0 && diry < 0) //Left down
        {
            rotate.z = 135;
        }
        if (dirx > 0 && diry < 0) //Right down
        {
            rotate.z = 225;
        }


        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotate);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage , transform.position);
            PierceReduce();
        }

    }

    void PierceReduce()
    {
        currentPierce--;

        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
