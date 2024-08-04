using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool _resetJumpNeeded = false; 
    [SerializeField]
    private LayerMask _layerMask;
    private bool _isGrounded = false;
    //Handles
    private Rigidbody2D _rigidbody2d;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSprite;
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        Movement();
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
        if (hit.collider != null)
        {
            if(_resetJumpNeeded == false)
            {
                Debug.Log("Jump anim false");
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
        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;
        }

    }

}
