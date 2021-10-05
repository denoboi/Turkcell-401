using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;
    [SerializeField]
    float jumpSpeed;

    [SerializeField]
    float speed =default;
    [SerializeField]
    float acceleration = default;
    [SerializeField]
    float deceleration = default;

  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControl();
    }

    void KeyboardControl()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if (moveInput > 0)
        {
            //Ikinci deger ulasmak istedigimiz o da move inputa gore degisecek
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);

            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
     

        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);

            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }

        //Yani duruyorsa
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            StopJump();
        }
    }

    void Jump()
    {
         rb2d.AddForce(new Vector2(0,jumpSpeed), ForceMode2D.Impulse);
         animator.SetBool("Jump", true);
    }

    void StopJump()
    {
        animator.SetBool("Jump", false);
    }
}
