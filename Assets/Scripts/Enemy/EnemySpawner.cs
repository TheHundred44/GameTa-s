using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;

    public GameObject slowEnemy;
    public GameObject fastEnemy;

    public float minTime = 1f;
    public float maxTime = 2f;

    public float activationDistance = 5f; // distance au bas de la zone
    public EnemyData[] enemies;


    private BoxCollider col;

    void Start()
    {
        col = GetComponent<BoxCollider>();
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            if (IsPlayerNearBottom())
            {
                SpawnEnemy();
            }
        }
    }

    bool IsPlayerNearBottom()
    {
        float bottomY = col.bounds.min.y;

        return player.position.y >= bottomY - activationDistance;
    }

    void SpawnEnemy()
    {
        Bounds bounds = col.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPos = new Vector3(x, y, 0);

        GameObject enemyPrefab = GetRandomEnemy();
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // 🔥 AJOUT ICI
        //EnemySpeed es = enemy.GetComponent<EnemySpeed>();

        //if (es != null)
        //{
        //    EnemyWeak ew = enemy.GetComponent<EnemyWeak>();

        //}
    }

    GameObject GetRandomEnemy()
    {
        float totalWeight = 0f;

        foreach (var e in enemies)
            totalWeight += e.weight;

        float random = Random.Range(0, totalWeight);

        foreach (var e in enemies)
        {
            if (random < e.weight)
                return e.prefab;

            random -= e.weight;
        }

        return enemies[0].prefab;
    }
}
