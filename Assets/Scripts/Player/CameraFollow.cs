using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    float offsetY;

    void Start()
    {
        offsetY = transform.position.y - player.position.y;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = player.position.y + offsetY;
        transform.position = pos;
    }
}
