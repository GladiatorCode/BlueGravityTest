using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private float maxSpeedForNormalAnimation = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Calculate character move speed
        float moveSpeed = rb.velocity.magnitude;

        // Set the "Speed" parameter in the Animator Controller
        animator.SetFloat("Speed", moveSpeed);

        // Calculate the normalized animation speed
        float normalizedSpeed = moveSpeed / maxSpeedForNormalAnimation;

        // Adjust the animator's speed based on the normalized animation speed
        animator.speed = normalizedSpeed;
    }
}
