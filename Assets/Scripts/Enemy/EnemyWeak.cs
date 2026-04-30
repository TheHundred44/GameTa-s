using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeak : MonoBehaviour
{
    [Header("Réglages au Spawn")]
    public bool flipOnSpawn = false;

    public float speed = 2f;
    public int direction = 0;

    [Header("Paramètres de Vol")]
    public float amplitude = 0.5f; // Hauteur du mouvement (haut/bas)
    public float frequency = 2f;  // Vitesse du balancement

    private float startY;
    private PlayerHealtth life;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        life = FindObjectOfType<PlayerHealtth>();
        // On mémorise la hauteur de départ pour osciller autour
        startY = transform.position.y;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Déplacement horizontal (ton code actuel)
        Vector3 horizontalMove = (direction == 0) ? Vector3.left : Vector3.right;
        transform.position += horizontalMove * speed * Time.deltaTime;

        // 2. Effet de vol (oscillation verticale)
        // On calcule la nouvelle position Y avec Sinus
        float newY = startY + Mathf.Sin(Time.time * frequency) * amplitude;

        // On applique la nouvelle hauteur
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Attention : Vérifie si ton jeu est en 2D (OnTriggerEnter2D) ou 3D (Collider)
        if (collision.CompareTag("Player"))
        {
            if (life != null) life.LifeHit();
        }
    }

    public void FlipEnemy()
    {
        // Option A : Retourner le visuel du Sprite (le plus simple)
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = true;
        }
    }
}
