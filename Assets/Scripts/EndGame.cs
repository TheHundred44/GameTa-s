using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endScreen;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();

            player.enabled = false; 

            Animator anim = collision.GetComponent<Animator>();
            //anim.SetTrigger("Finish");

            ShowEndScreen();
        }
    }

    void ShowEndScreen()
    {
        endScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
