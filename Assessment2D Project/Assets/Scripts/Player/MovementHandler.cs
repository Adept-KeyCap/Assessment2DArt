using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementHandler : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField, Range(1,10)] private float maxSpeed;
    [SerializeField, Range(1,10)] private float jumpForce;

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


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Move(2);
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
                    break;

                case 1:
                    rb.velocity = rb.velocity + new Vector2(-0.3f, 0);

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
