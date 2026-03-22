using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeak : MonoBehaviour
{
    public float speed = 2f;
    PlayerHealtth life;
    public int direction = 0;

    private void Start()
    {
        life = FindObjectOfType<PlayerHealtth>();
    }

    void Update()
    {
        if(direction == 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            life.LifeHit();
        }
    }
}
