using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rigidbody;
    public float speed = 10f;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Movement(horizontal);


    }

    private void Movement(float horizontal) {

        if(horizontal == 0f) {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            rigidbody.velocity = Vector2.zero;
        }else if(horizontal > 0 && facingRight) {
            rigidbody.velocity = new Vector2(horizontal, rigidbody.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }else if (horizontal > 0 && !facingRight) {
            facingRight = true;
            Flip();
            rigidbody.velocity = new Vector2(horizontal, rigidbody.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }else if(horizontal < 0 && facingRight) {
            facingRight = false;
            Flip();
            rigidbody.velocity = new Vector2(horizontal, rigidbody.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }else if (horizontal < 0 && !facingRight) {
            rigidbody.velocity = new Vector2(horizontal, rigidbody.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }

        if (Input.GetButtonDown("Jump")){
            rigidbody.velocity = Vector2.up * 20;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsJumping", false);
        }
    }

    public void Flip() {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
