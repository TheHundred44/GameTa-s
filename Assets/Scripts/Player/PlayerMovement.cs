using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float autoVerticalSpeed = 5f;
    public float boostSpeed = 10f;
    public float horizontalSpeed = 10f;

    public Animator animator;

    public ParticleSystem particleJump;

    public Animator animatorTransition;
    public UseTransition useTransition;

    private Camera mainCamera;

    public float speedMultiplier = 1f; // Par défaut, la vitesse est normale (x1)

    private void Start()
    {
        mainCamera = Camera.main;

        animatorTransition.SetTrigger("Open");
        useTransition.CanOpen = true;


        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Jump");
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float moveY = autoVerticalSpeed * speedMultiplier * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);
        KeepPlayerInBounds();

        //if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        //{
        //    speed = boostSpeed;
        //    particleJump.Play();
        //    animator.SetTrigger("Jump");
        //}

        //transform.position += Vector3.up * speed * Time.deltaTime;

        //float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(moveX, 0, 0);
    }

    void KeepPlayerInBounds()
    {
        // On convertit la position du joueur en "Viewport Space" (0 = gauche, 1 = droite)
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // On limite la valeur entre 0.05 et 0.95 (pour garder une petite marge du bord)
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0.05f, 0.95f);

        // On reconvertit cette position limitée en coordonnées "World"
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
    }

    public void ApplySpeedBoost(float multiplier, float duration)
    {
        StartCoroutine(BoostCoroutine(multiplier, duration));
    }

    private IEnumerator BoostCoroutine(float multiplier, float duration)
    {
        speedMultiplier = multiplier; // On active le boost
        yield return new WaitForSeconds(duration); // On attend
        speedMultiplier = 1f; // On revient à la normale
    }
}
