using UnityEngine;
using UnityEngine.EventSystems; // Obligatoire pour la détection de souris

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.1f; // Taille de l'agrandissement
    public float speed = 10f;       // Vitesse de transition

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        // Transition fluide vers la taille cible
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Quand la souris entre
        targetScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Quand la souris sort
        targetScale = originalScale;
    }
}
