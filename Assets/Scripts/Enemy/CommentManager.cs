using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentManager : MonoBehaviour
{
    [Header("Liste de tes visuels (Prefabs)")]
    public GameObject[] commentPrefabs; // Glisse ici tes différents designs de bulles

    public RectTransform spawnArea; // La zone du Canvas où ils apparaissent

    public void TriggerCommentSplash(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // Apparition décalée pour l'effet "vague"
            Invoke("SpawnSingleComment", i * 0.08f);
        }
    }

    void SpawnSingleComment()
    {
        GameObject randomPrefab = commentPrefabs[Random.Range(0, commentPrefabs.Length)];

        // 1. Instancier SANS parent d'abord
        GameObject go = Instantiate(randomPrefab);

        // 2. Lui donner le parent en précisant 'false' pour worldPositionStays
        // C'est ce 'false' qui empêche Unity de changer le scale
        go.transform.SetParent(spawnArea, false);

        // 3. Maintenant on règle la position et la rotation
        RectTransform rect = go.GetComponent<RectTransform>();

        float x = Random.Range(-spawnArea.rect.width / 2f, spawnArea.rect.width / 2f);
        float y = Random.Range(-spawnArea.rect.height / 2f, spawnArea.rect.height / 2f);

        rect.anchoredPosition = new Vector2(x, y);
        go.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-20f, 20f));

        // 4. Par sécurité, on s'assure que le scale est bien celui du prefab (1,1,1)
        go.transform.localScale = Vector3.one;

        if (go.TryGetComponent(out CommentLife life))
        {
            life.StartFade(1.5f, 0.8f);
        }
    }
}
