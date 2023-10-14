using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerControlls : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpForce = 15;
    Rigidbody2D RB;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float glidingSpeed;
    private float initialGravityScale;
    public Vector2 Velocity;
    [HideInInspector] public bool bGrappleReady = false;
    private bool bGrappleOn;
    public Animator Animator;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        initialGravityScale = RB.gravityScale;
        GetComponentInChildren<GrappleRope>().gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && IsTouch())
        {
            RB.velocity = new Vector2(RB.velocity.x, jumpForce);
            StartCoroutine( HopA());
        }
        if (Input.GetButtonUp("Jump") && !IsTouch())
        {
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
        }
        if (bGrappleReady && Input.GetButtonDown("Fire1"))
        {
            GrappleAbility();
        }
        if (Input.GetButtonDown("Fire2") && !IsTouch())
        {
            Glide();
        }
        Flip();
    }
    private void FixedUpdate()
    {
        RB.velocity = new Vector2(horizontal * speed, RB.velocity.y);
        GroundTouch();
    }
    private bool IsTouch()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Flip()
    {
        if (horizontal > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 0.5f;
            transform.localScale = localScale;
        }
        else if (horizontal < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -0.5f;
            transform.localScale = localScale;
        }
    }
    void GrappleAbility()
    {
        if (!bGrappleOn)
        {
            GetComponent<SpringJoint2D>().enabled = true;
            GetComponentInChildren<GrappleRope>().gameObject.GetComponent<SpriteRenderer>().enabled = true;
            bGrappleOn = true;
        }
        else
        {
            GetComponent<SpringJoint2D>().enabled = false;
            GetComponentInChildren<GrappleRope>().gameObject.GetComponent<SpriteRenderer>().enabled = false;
            bGrappleOn = false;
        }
    }
    void GroundTouch()
    {
        if(Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
        {
            RB.gravityScale = initialGravityScale;
            Animator.SetBool("STILLGOIN", false);
            Animator.SetBool("IsGliding", false);
        }
    }
    void Glide()
    {
        if (RB.velocity.y < 0 && !bGrappleOn)
        {
            RB.gravityScale = 0.3f;
            Animator.SetBool("IsGliding", true);
            Animator.SetBool("STILLGOIN", true);
        }
    }
    IEnumerator HopA()
    {
        Animator.SetBool("IsJumping", true);
        yield return new WaitForSeconds(1);
        Animator.SetBool("IsJumping", false);
    }
}

