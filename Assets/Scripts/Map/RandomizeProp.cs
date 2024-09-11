using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeProp : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public List<GameObject> PrefabsProp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn ()
    {
        foreach (GameObject sp in SpawnPoints)
        {
            int R = Random.Range(0, PrefabsProp.Count);
            GameObject prop = Instantiate(PrefabsProp[R], sp.transform.position,Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}
