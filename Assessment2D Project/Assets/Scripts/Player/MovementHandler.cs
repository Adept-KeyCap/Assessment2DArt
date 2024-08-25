using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField, Range(1,10)] private float maxSpeed;
    [SerializeField, Range(1,10)] private float jumpForce;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public static MovementHandler Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this);
        }
        else
        {
            Instance = this;
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (rb != null) 
        {
            if (Input.GetKey(KeyCode.D))
            {
                Move(0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Move(1);
            }
            else
            {
                animator.SetBool("moving", false);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Move(2);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void Move(int moveIndex)
    {
        if (rb.velocity.x <= maxSpeed && rb.velocity.x >= -maxSpeed)
        {
            switch (moveIndex)
            {

                case 0:
                    rb.velocity = rb.velocity + new Vector2(0.3f, 0);
                    animator.SetBool("moving", true);
                    break;

                case 1:
                    rb.velocity = rb.velocity + new Vector2(-0.3f, 0);
                    animator.SetBool("moving", true);
                    spriteRenderer.flipX = true;
                    break;

                case 2:
                    rb.velocity = rb.velocity + new Vector2(0, jumpForce);

                    break;

                case 3:
                    rb.velocity = rb.velocity + new Vector2(0, 0);

                    break;
            }
        }
        
    }
}
