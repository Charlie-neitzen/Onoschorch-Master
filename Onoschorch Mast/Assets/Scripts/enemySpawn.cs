﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private int xPos;
    private int zPos;
    public int enemyCount;
    public int toSpawn = 20;
    public AudioSource[] zombieSounds;

    void Start()
    {
        StartCoroutine(EnemyDrop());
        InvokeRepeating("TimedEnemyDrop", 3f, 1f);

    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < toSpawn)
        {
            xPos = Random.Range(12, 90);
            zPos = Random.Range(32, 87);
            Instantiate(enemy, new Vector3(xPos, 10, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            zombieSounds[Random.Range(0,2)].Play();
            enemyCount += 1;
        }
    }

    void TimedEnemyDrop()
    {
         xPos = Random.Range(2, 64);
         zPos = Random.Range(10, 72);
         Instantiate(enemy, new Vector3(xPos, 10, zPos), Quaternion.identity);
    }
}
