using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float cooldown = 1;
    public float radius = 3;
    
    void Start()
    {
        StartCoroutine(spawnLoop());
    }

    IEnumerator spawnLoop()
    {
        yield return new WaitForSeconds(cooldown);
        GameObject g = Instantiate(enemyPrefab);
        float rad = Random.Range(0, 2 * Mathf.PI);
        
        Vector3 position = new Vector3(radius * Mathf.Cos(rad), 0, radius * Mathf.Sin(rad));
        g.transform.position += position;
        
        StartCoroutine(spawnLoop());
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        List<Vector3> p = new List<Vector3>();
        
        for (int i = 0; i <= 10; i++)
        {
            p.Add(new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * i * 36), 0, radius * Mathf.Sin(Mathf.Deg2Rad * i * 36)));
        }
        
        Gizmos.DrawLineStrip(p.ToArray(), true);
    }
}
