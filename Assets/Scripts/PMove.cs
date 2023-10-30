using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private Controls pInput = new Controls();
    private Rigidbody2D rBody;
    private Transform groundCheck;
    private LayerMask groundLayer;
    private Vector2 Velocity;
    private bool bGrappleReady, bGrappleOn;
    private float pDir, speed, glidingSpeed, initialGScale, jumpForce = 15;
    
    private void Start()
    {
        pInput.Enable();
        rBody = GetComponent<Rigidbody2D>();
        initialGScale = rBody.gravityScale;
    }

    private void Update()
    {
        pDir = pInput.Player.Movement.ReadValue<Vector2>().x;
        Animator.SetFloat("Speed", Mathf.Abs(pDir));

        Flip();
    }

    private void Flip()
    {//Switch direction of sprite based on direction of movement.
        Vector3 lScale = transform.localScale;
        if (pDir > 0)
        {
            lScale.x = 0.5f;
        }
        else
        {
            lScale.x = -0.5f;
        }
        transform.localScale = lScale;
    }
}
