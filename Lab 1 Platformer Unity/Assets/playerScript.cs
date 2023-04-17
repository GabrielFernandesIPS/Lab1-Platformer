using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    [SerializeField] private float _jumpPower = 2.0f;
    [SerializeField] private float _runSpeed = 0.5f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private GameObject _groundTestLineStart;
    [SerializeField] private GameObject _groundTestLineEnd;
    [SerializeField] private bool _doubleJumpEnabled;
    private bool _jumpEnded;
    private bool _canAirJump;
    [SerializeField] private float _jumpCommandTime;
    [SerializeField] private float _jumpBufferTime;
    [SerializeField] private float _groundedTime;
    [SerializeField] private bool _canJump;
    [SerializeField] private float _coyoteTime;

    [SerializeField] private float _playerLife;

    private bool _jumpCommand;
    private bool _leftCommand;
    private bool _rightCommand;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Controles de Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpCommand = true;
            _jumpCommandTime = Time.unscaledTime;
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

    public void PlayerTakeDamage(float damage)
    {
        _playerLife -= damage;
        if( _playerLife <= 0 ) 
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Morri");
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Linecast(_groundTestLineEnd.transform.position,
                        _groundTestLineStart.transform.position);

        if(_isGrounded){
            _groundedTime = Time.unscaledTime;
            _canJump = true;
        }else{
            if(Time.unscaledTime - _groundedTime > _coyoteTime){
                _canJump = false;
            }
        }
        string animation = "IdleAnimation";
        if (!_isGrounded)
        {
            if (_rb.velocity.y > 0)
            {
                animation = "JumpAnimation";
            }
            else
            {
                animation = "FallAnimation";
            }
        }
                
        if (_jumpCommand && _canJump && Time.unscaledTime - _jumpCommandTime < _jumpBufferTime)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _jumpCommand = false;
            _canAirJump = true;
        }
        if (_doubleJumpEnabled && _jumpCommand && !_isGrounded && _canAirJump && _rb.velocity.y < 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _jumpCommand = false;
            _canAirJump = false;
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
            animation = "RunAnimation";
        }

        else if (_rightCommand)
        {
            _rb.velocity = new Vector2(_runSpeed, _rb.velocity.y);
            _rightCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
            animation = "RunAnimation";
        }

        _animator.Play(animation);
    }
}
