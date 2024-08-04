﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        _animator.SetFloat("Move",Mathf.Abs(move));
    }
    public void Jump(bool jump)
    {
        _animator.SetBool("Jumping", jump);
    }
}
