using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour,IDamageable
{
    // Variables
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool _resetJumpNeeded = false; 
    private bool _isGrounded = false;
    public int Diamond = 0;

    //Handles
    [SerializeField]
    private LayerMask _layerMask;
    private Rigidbody2D _rigidbody2d;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordSprite;

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Movement();
        
        if(Input.GetMouseButtonDown(0) && _IsGrounded() == true) 
        {
            _playerAnimation.Attack();
        }
    }
    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _isGrounded = _IsGrounded();
        Flip(move);
        if (Input.GetKeyDown(KeyCode.Space) && _IsGrounded() == true)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce);
            StartCoroutine(resetJumpNeeded());
            _playerAnimation.Jump(true);
        }

        _rigidbody2d.velocity = new Vector2(move * _speed, _rigidbody2d.velocity.y);
        _playerAnimation.Move(move);
    }
    private bool _IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _layerMask);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hit.collider != null)
        {
            //Debug.Log("Grounded");
            if(_resetJumpNeeded == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    IEnumerator resetJumpNeeded()
    {
        _resetJumpNeeded = true;
         yield return new WaitForSeconds(1.0f);
        _resetJumpNeeded = false;
    }
    void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
             _swordSprite.flipY = false;
        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;
            _swordSprite.flipY = true;
        }

    }
    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log("Player::Damage");
    }
}
