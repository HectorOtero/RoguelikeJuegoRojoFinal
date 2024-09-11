using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    public GameObject targetMap;
    MapController mp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mp = FindAnyObjectByType<MapController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mp.ActualMap = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(mp.ActualMap == targetMap) 
            { 
            mp.ActualMap = null;
            }
        }
    }
}
