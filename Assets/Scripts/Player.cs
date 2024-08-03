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
        float move = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && _ground == true)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpForce);
            _ground = false;
            _resetJumpNeeded = true;
            StartCoroutine(resetJumpNeeded());
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,0.6f,_layerMask);
        Debug.DrawLine(transform.position, Vector2.down * 0.6f,Color.green);
        if (hit.collider != null)
        {
            Debug.Log("Hit " +  hit.collider.name);
            if(_resetJumpNeeded == false) 
            {
                _ground = true;
            }
            
        }
        _rigidbody2d.velocity = new Vector2(move * _speed, _rigidbody2d.velocity.y);

    }
    IEnumerator resetJumpNeeded()
    {
         yield return new WaitForSeconds(1.0f);
        _resetJumpNeeded = false;
    }
}
