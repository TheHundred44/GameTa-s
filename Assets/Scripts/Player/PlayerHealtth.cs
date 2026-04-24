using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class PlayerHealtth : MonoBehaviour
{
    //public int life = 2;
    //public GameObject[] LifeIndicator;
    public GameObject LoseGameScreen;

    //public void LifeHit()
    //{
    //    LifeIndicator[life].SetActive(false);
    //    life--;
    //    if(life <= 0)
    //    {
    //        Time.timeScale = 0;
    //        LoseGameScreen.SetActive(true);
    //    }
    //}

    public int maxHealth = 3;
    public int currentHealth;

    [Header("UI : Objets du Churros")]
    // Glisse ici tes 4 objets (0 HP, 1 HP, 2 HP, 3 HP)
    public GameObject[] churrosObjects;

    [Header("Paramètres d'Invincibilité")]
    public float invincibilityDuration = 2f;
    public float blinkInterval = 0.2f;
    private bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateVisual();
    }

    public void LifeHit()
    {
        if (isInvincible) return;

        currentHealth --;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateVisual();

        if (currentHealth > 0)
        {
            StartCoroutine(BecomeInvincible());
        }
        else
        {
            Time.timeScale = 0;
            LoseGameScreen.SetActive(true);
            Debug.Log("Game Over !");
        }
    }

    private IEnumerator BecomeInvincible()
    {
        isInvincible = true;

        // On cherche le SpriteRenderer dans le skin actuellement actif
        SpriteRenderer activeSkin = GetComponentInChildren<SpriteRenderer>(false);

        if (activeSkin != null)
        {
            float timer = 0;
            while (timer < invincibilityDuration)
            {
                activeSkin.enabled = !activeSkin.enabled;
                yield return new WaitForSeconds(blinkInterval);
                timer += blinkInterval;
            }
            activeSkin.enabled = true;
        }

        isInvincible = false;
    }

    void UpdateVisual()
    {
        // On parcourt tous les objets du tableau
        for (int i = 0; i < churrosObjects.Length; i++)
        {
            if (churrosObjects[i] != null)
            {
                // On n'active que l'objet dont l'index correspond aux PV actuels
                churrosObjects[i].SetActive(i == currentHealth);
            }
        }
    }
}
