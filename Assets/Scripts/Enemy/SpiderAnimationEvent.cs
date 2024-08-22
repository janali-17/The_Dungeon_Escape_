﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    Spider _spider;

    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        Debug.Log("Spider Fire");
        _spider.Attack();
    }
}
