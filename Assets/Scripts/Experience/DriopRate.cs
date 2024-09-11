using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DriopRate : MonoBehaviour
{
    [System.Serializable]

    public class Drops
    {
        public string name;
        public GameObject item;
        public float dropRate;
    }

    public List<Drops> drops;

    private void OnDestroy()
    {
        float RandomPorcentage = Random.Range(0f, 100f);
        List<Drops> possibleDrops = new List<Drops>();


        foreach(Drops rate in drops)
        {
            if (RandomPorcentage <= rate.dropRate)
            {
               possibleDrops.Add(rate);
            }
        }
        if (possibleDrops.Count > 0)
        {
            Drops drops = possibleDrops[Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.item, transform.position, Quaternion.identity);
        }

        
    }
}
