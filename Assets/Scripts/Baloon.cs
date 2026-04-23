using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    public float boostAmount = 15f; // Vitesse x1.5
    public float boostDuration = 3f; // Pendant 3 secondes
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();

            if (movement != null)
            {
                movement.ApplySpeedBoost(boostAmount, boostDuration);
            }
            FindObjectOfType<ScoreManager>().AddScore(1);
            Destroy(gameObject);
        }

    }

}
