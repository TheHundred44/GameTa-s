using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string NameOfScene;

    public void ButtonSwwitchScene(string gameObject)
    {
        SceneManager.LoadScene(gameObject);
    }

    public void PlayStart(int index)
    {
        SelectCharacter.Number = index;
        SceneManager.LoadScene("Game");
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
    }
}
