using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    public List<GameObject> Map;
    public GameObject Player;
    public float radius;
    Vector3 TerrainPosition;
    public LayerMask Mask;
    public GameObject ActualMap;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> Spawned;
    GameObject LatestSpawned;
    public float maxDis;
    float opDist;
    float cooldown;
    public float cooldownduration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Checker();
        Optimization();
    }

    void Checker ()
    {
        if (!ActualMap)
        {
            return;
        }

        if (pm.Joystickmovement.Direction.x > 0 && pm.Joystickmovement.Direction.y > 0) //right
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("Right").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("Right").position;
                Spawn();

            }

        }
        else if (pm.Joystickmovement.Direction.x < 0 && pm.Joystickmovement.Direction.y < 0) //left
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("Left").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("Left").position;
                Spawn();

            }

        }
        if (pm.Joystickmovement.Direction.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("Up").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("Up").position;
                Spawn();

            }

        }
        if (pm.Joystickmovement.Direction.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("Down").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("Down").position;
                Spawn();

            }

        }
        if (pm.Joystickmovement.Direction.x > 0 && pm.Joystickmovement.Direction.y > 0) //up right
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("RightUp").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("RightUp").position;
                Spawn();

            }

        }
        if (pm.Joystickmovement.Direction.x < 0 && pm.Joystickmovement.Direction.y > 0) //up left
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("RightLeft").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("RightLeft").position;
                Spawn();

            }

        }
        if (pm.Joystickmovement.Direction.x > 0 && pm.Joystickmovement.Direction.y < 0) //down right
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("DownRight").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("DownRight").position;
                Spawn();

            }

        }
        if (pm.Joystickmovement.Direction.x < 0 && pm.Joystickmovement.Direction.y < 0) //down left
        {
            if (!Physics2D.OverlapCircle(ActualMap.transform.Find("DownLeft").position, radius, Mask))
            {
                TerrainPosition = ActualMap.transform.Find("DownLeft").position;
                Spawn();

            }

        }
    }

    void Spawn ()
    {
        int random = Random.Range(0, Map.Count);
        LatestSpawned = Instantiate(Map[random], TerrainPosition, Quaternion.identity );
        Spawned.Add(LatestSpawned);
    }

    void Optimization()
    {
        cooldown -= Time.deltaTime;

        if ( cooldown <= 0 )
        {
            cooldown = cooldownduration;
        }
        else
        {
            return;
        }
        foreach(GameObject mapi in Spawned)
        {
            opDist = Vector3.Distance(Player.transform.position, mapi.transform.position);
            if (opDist > maxDis)
            {
                mapi.SetActive(false);
            }
            else
            {
                mapi.SetActive(true);
            }
        }
    }
}
