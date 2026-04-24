using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloatingUI : MonoBehaviour
{
    [Header("Paramètres")]
    public float amplitude = 20f; // En pixels pour l'UI
    public float frequency = 1f;

    private RectTransform rectTransform;
    private Vector2 startAnchoredPos;
    private float randomOffset;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPos = rectTransform.anchoredPosition;

        // On ajoute un décalage aléatoire pour que tous les textes 
        // ne montent pas en même temps (plus naturel)
        randomOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Calcul du mouvement sinusoïdal
        float newY = Mathf.Sin((Time.time * frequency) + randomOffset) * amplitude;

        // On applique au RectTransform pour l'UI
        rectTransform.anchoredPosition = startAnchoredPos + new Vector2(0, newY);
    }
}
