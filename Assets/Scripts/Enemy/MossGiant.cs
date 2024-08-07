using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MossGiant : Enemy
{
    private bool isIdle;
    private Vector3 _currentTarget;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        Attack();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Update()
    {
        isIdle = _animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim");
        if(isIdle)
        {
            return;
        }
       Movement();
    }

    private void Movement()
    {
        if (transform.position == WaypointA.position)
        {
            _currentTarget = WaypointB.position;
            _spriteRenderer.flipX = false;
        }
        else if (transform.position == WaypointB.position)
        {
            _currentTarget = WaypointA.position;
            _spriteRenderer.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        if (transform.position == _currentTarget)
        {
            _animator.SetTrigger("Idle");
        }
    }
  
}
