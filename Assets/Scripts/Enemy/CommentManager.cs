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

        // Utilise cette version de Instantiate, c'est la plus propre pour l'UI
        GameObject go = Instantiate(randomPrefab, spawnArea);

        RectTransform rect = go.GetComponent<RectTransform>();

        float x = Random.Range(-spawnArea.rect.width / 2f, spawnArea.rect.width / 2f);
        float y = Random.Range(-spawnArea.rect.height / 2f, spawnArea.rect.height / 2f);

        rect.anchoredPosition = new Vector2(x, y);
        go.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-20f, 20f));

        // SUPPRIME CETTE LIGNE :
        // go.transform.localScale = Vector3.one; 

        // L'objet va maintenant garder le scale défini dans son Prefab !

        if (go.TryGetComponent(out CommentLife life))
        {
            life.StartFade(1.5f, 0.8f);
        }
    }
}
