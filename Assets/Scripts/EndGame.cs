using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject persoN;
    public GameObject persoN2;
    public GameObject persoF;
    public GameObject persoF2;

    public Score score;

    private void Awake()
    {
        persoF.SetActive(false);
        persoF2.SetActive(false);
        persoN2.SetActive(true);
        persoN.SetActive(true);
    }

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
        persoN.SetActive(false);
        persoN2.SetActive(false);
        persoF2.SetActive(true);
        persoF.SetActive(true);
        endScreen.SetActive(true);
        score.AfficherResultatsFinaux();
        Time.timeScale = 0.0f;
    }
}
