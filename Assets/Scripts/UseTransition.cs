using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTransition : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    public bool CanOpen = false;

    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(WaitForTransition());
    }
    private void Update()
    {
        if (CanOpen)
        {
            StartCoroutine(WaitForTransition());
        }
    }

    IEnumerator WaitForTransition()
    {
        yield return new WaitForSecondsRealtime(1f);
        CanOpen = false;
        StartGame();
    }

    void StartGame()
    {
        Time.timeScale = 1f;
    }
}
