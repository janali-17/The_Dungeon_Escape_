﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    void Start()
    {
        Attack();
    }
    public override void Attack()
    {
        Debug.Log("Spider is Attacking");
    }
    public override void Update()
    {
        Debug.Log("Spider is Updating");
    }

}
