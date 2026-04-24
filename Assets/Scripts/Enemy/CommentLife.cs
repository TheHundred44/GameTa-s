using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CommentLife : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Vector3 targetScale;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // AU LIEU DE : transform.localScale = Vector3.zero;
        // ON FAIT :
        targetScale = transform.localScale; // On mémorise si c'est 0.5, 1.2, etc.
        transform.localScale = Vector3.zero; // On met à zéro pour l'anim
    }

    void Start()
    {
        // Lance l'animation d'apparition dès que l'objet est créé
        StartCoroutine(PopIn());
    }

    // Effet de zoom à l'apparition
    private IEnumerator PopIn()
    {
        float duration = 0.25f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float percent = Mathf.SmoothStep(0, 1, elapsed / duration);

            // ON APPLIQUE LE POURCENTAGE SUR LA TAILLE CIBLE
            transform.localScale = targetScale * percent;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    // Cette fonction est appelée par le CommentManager
    public void StartFade(float delay, float fadeDuration)
    {
        StartCoroutine(FadeOutRoutine(delay, fadeDuration));
    }

    private IEnumerator FadeOutRoutine(float delay, float duration)
    {
        // 1. Attend avant de commencer à disparaître
        yield return new WaitForSeconds(delay);

        // 2. Fondu progressif (Alpha de 1 vers 0)
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            yield return null;
        }

        // 3. Détruit l'objet pour libérer la mémoire
        Destroy(gameObject);
    }
}
