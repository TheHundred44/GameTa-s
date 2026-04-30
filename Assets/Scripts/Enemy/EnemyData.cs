using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class EnemyData : MonoBehaviour
{

    public GameObject prefab;
    public float weight; // probabilité
    public bool flip = false;

    public EnemySpeed speed;
    public EnemyWeak EnemyWeak;

    private void Start()
    {
        if (prefab.TryGetComponent(out EnemyWeak week))
        {
            if (!flip)
            {
                week.FlipEnemy();
            }
        }
        else if (prefab.TryGetComponent(out EnemySpeed speed))
        {
            if (!flip)
            {
                speed.FlipEnemy();
            }
        }
    }
}



