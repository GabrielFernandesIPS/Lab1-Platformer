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


    private bool _jumpCommand;
    private bool _leftCommand;
    private bool _rightCommand;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpCommand = true;
        }

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
