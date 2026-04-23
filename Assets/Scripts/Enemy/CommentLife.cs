using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CommentLife : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // On initialise l'objet invisible et tout petit
        canvasGroup.alpha = 1f;
        transform.localScale = Vector3.zero;
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
            // Utilise une courbe douce (SmoothStep) pour le zoom
            float percent = Mathf.SmoothStep(0, 1, elapsed / duration);
            transform.localScale = Vector3.one * percent;
            yield return null;
        }

        transform.localScale = Vector3.one;
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
