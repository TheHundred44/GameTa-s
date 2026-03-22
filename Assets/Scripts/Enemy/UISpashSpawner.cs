using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpashSpawner : MonoBehaviour
{
    public Image[] splashes;
    public float spawnDelay = 0.2f;

    void Start()
    {
        StartCoroutine(PlaySplash());
    }

    IEnumerator PlaySplash()
    {
        foreach (Image img in splashes)
        {
            img.gameObject.SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }

        yield return new WaitForSeconds(3f);

        foreach (Image img in splashes)
        {
            img.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
}
