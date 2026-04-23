using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloon : MonoBehaviour
{
    public GameObject objectToSpawn;
    private BoxCollider spawnArea;

    void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
        SpawnObject();
    }

    public void SpawnObject()
    {
        Bounds bounds = spawnArea.bounds;

        // On génère une position aléatoire dans les limites du BoxCollider
        Vector3 randomPos = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(-0.2861241f, -0.2861241f)
        );

        Instantiate(objectToSpawn, randomPos, Quaternion.identity);
    }
}
