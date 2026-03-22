using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtth : MonoBehaviour
{
    public int life = 4;
    public GameObject[] LifeIndicator;
    public GameObject LoseGameScreen;

    public void LifeHit()
    {
        LifeIndicator[life].SetActive(false);
        life--;
        if(life <= 0)
        {
            Time.timeScale = 0;
            LoseGameScreen.SetActive(true);
        }
    }
}
