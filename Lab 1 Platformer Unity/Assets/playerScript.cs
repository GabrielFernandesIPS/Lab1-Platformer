using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool jumpCommand;   
    [SerializeField] private float jumpPower;
    [SerializeField] private float runSpeed;
    private bool leftCommand;
    private bool rightCommand;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpPower = 2.0f;
        runSpeed = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftCommand = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rightCommand = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpCommand)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCommand = false;    
        }
        if (leftCommand)
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            leftCommand = false;
            //Flip do Sprite que afeta os objetos filhos
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        if (rightCommand)
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            rightCommand = false;
            //Flip do Sprite que afeta os objetos filhos
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
    }
}
