using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float boostSpeed = 10f;

    public Animator animator;

    public ParticleSystem particleJump;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Jump");
    }

    void Update()
    {
        float speed = baseSpeed;

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            speed = boostSpeed;
            particleJump.Play();
            animator.SetTrigger("Jump");
        }

        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
