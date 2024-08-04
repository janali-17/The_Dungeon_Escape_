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
    private bool _ground = false;
    [SerializeField]
    private bool _resetJumpNeeded = false; 
    [SerializeField]
    private LayerMask _layerMask;
    //Handles
    private Rigidbody2D _rigidbody2d;
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Movement();
        
       

    }
    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && _IsGrounded() == true)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce);
            StartCoroutine(resetJumpNeeded());
        }

        _rigidbody2d.velocity = new Vector2(move * _speed, _rigidbody2d.velocity.y);
    }
    private bool _IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _layerMask);
        if (hit.collider != null)
        {
            if(_resetJumpNeeded == false)
            {
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

}
