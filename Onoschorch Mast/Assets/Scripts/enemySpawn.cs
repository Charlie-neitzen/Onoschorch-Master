using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private int xPos;
    private int zPos;
    private int enemyCount;
    public int toSpawn = 20;
    private int enabled = 1;

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
            enemyCount += 1;
        }
    }

    void TimedEnemyDrop()
    {
        if (enabled == 1)
        {
            xPos = Random.Range(2, 64);
            zPos = Random.Range(10, 72);
            Instantiate(enemy, new Vector3(xPos, 10, zPos), Quaternion.identity);
        }
    }

    void DestroyAll()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        PointSystem.points = 0;

    }
}
