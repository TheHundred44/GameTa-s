using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Paramètres de flottement")]
    public float amplitude = 0.5f; // La hauteur du mouvement (de haut en bas)
    public float frequency = 1f;   // La vitesse du mouvement

    private Vector3 startPos;

    void Start()
    {
        // On mémorise la position de départ pour ne pas que l'objet "dérive"
        startPos = transform.position;
    }

    void Update()
    {
        // On calcule la nouvelle position sur l'axe Y
        // Mathf.Sin crée une vague qui monte et descend entre -1 et 1
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;

        // On applique cette variation à la position de départ
        transform.position = startPos + new Vector3(0, newY, 0);
    }
}
