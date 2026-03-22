using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float boostSpeed = 10f;

    void Update()
    {
        float speed = baseSpeed;

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            speed = boostSpeed;
        }

        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
