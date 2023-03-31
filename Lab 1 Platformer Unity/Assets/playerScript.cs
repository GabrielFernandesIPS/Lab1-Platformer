using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _jumpPower = 2.0f;
    [SerializeField] private float _runSpeed = 0.5f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private GameObject _groundTestLineStart;
    [SerializeField] private GameObject _groundTestLineEnd;
    private bool _jumpEnded;


    private bool _jumpCommand;
    private bool _leftCommand;
    private bool _rightCommand;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Controles de Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpCommand = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _jumpEnded = true;
        }
        //Controles de Movimento
        if (Input.GetKey(KeyCode.A))
        {
            _leftCommand = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            _rightCommand = true;
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Linecast(_groundTestLineEnd.transform.position,
                        _groundTestLineStart.transform.position);

        if (_jumpCommand && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _jumpCommand = false;
        }
        if (_jumpEnded)
        {
            Vector2 v = new Vector2(_rb.velocity.x, _rb.velocity.y / 2.0f);
            _rb.velocity = v;
            _jumpEnded = false;
        }
        if (_leftCommand)
        {
            _rb.velocity = new Vector2(-_runSpeed, _rb.velocity.y);
            _leftCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }

        else if (_rightCommand)
        {
            _rb.velocity = new Vector2(_runSpeed, _rb.velocity.y);
            _rightCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
    }
}
