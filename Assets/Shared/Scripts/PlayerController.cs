using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    public LayerMask groundMask;
    public Transform groundPoint;

    private bool __isGrounded;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector2 __moveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        //spriteRenderer.receiveShadows = true;
        __moveInput.x = Input.GetAxis("Horizontal");
        __moveInput.y = Input.GetAxis("Vertical");
        

        theRB.velocity = new Vector3(__moveInput.x * moveSpeed, theRB.velocity.y, __moveInput.y * moveSpeed);

        animator.SetFloat("moveSpeed", theRB.velocity.magnitude * 0.05f);

        if (Physics.Raycast(groundPoint.position, Vector3.down, out RaycastHit hit, .3f, groundMask)) {
            __isGrounded = true;
        } 
        else 
        {
            __isGrounded = false;
        }
        if (Input.GetButtonDown("Jump") && __isGrounded) 
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }
        animator.SetBool("onGround", __isGrounded);

        if (spriteRenderer.flipX && __moveInput.x < 0) 
        {
            spriteRenderer.flipX = false;
        }
        else if (!spriteRenderer.flipX && __moveInput.x > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
