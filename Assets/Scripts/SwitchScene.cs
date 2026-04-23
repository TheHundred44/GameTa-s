using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string NameOfScene;
    public Animator animator;
    public UseTransition useTransition;


    public void ButtonSwwitchScene(string gameObject)
    {
        useTransition.CanOpen = true;

        animator.SetTrigger("Close");
        SceneManager.LoadScene(gameObject);
        Time.timeScale = 1.0f;


    }

    public void PlayStart(int index)
    {
        useTransition.CanOpen = true;
        SelectCharacter.Number = index;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
        animator.SetTrigger("Close");
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }

    public void Retry()
    {
        useTransition.CanOpen = true;

        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
        animator.SetTrigger("Close");

    }
}
