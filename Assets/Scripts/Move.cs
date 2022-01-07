using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public float runSpeed=2;
	public float jumpSpeed=3;
	Rigidbody2D rb2D;
	public SpriteRenderer SpriteRenderer;
	public Animator animator;

    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
        	rb2D.velocity=new Vector2(runSpeed, rb2D.velocity.y);
        	SpriteRenderer.flipX=false;
        	animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
        	rb2D.velocity=new Vector2(-runSpeed, rb2D.velocity.y);
        	SpriteRenderer.flipX=true;
        	animator.SetBool("Run", true);
        }
        else
        {
        	rb2D.velocity=new Vector2(0, rb2D.velocity.y);
        	animator.SetBool("Run", false );
        }
        if (Input.GetKey("space") && Checkground.isGrounded)
        {
        	rb2D.velocity=new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        if (Checkground.isGrounded==false)
        {
        	animator.SetBool("Jump", true);
        	animator.SetBool("Run", false);
        }
        if (Checkground.isGrounded==true)
        {
        	 animator.SetBool("Jump", false);
        }
    }
}
