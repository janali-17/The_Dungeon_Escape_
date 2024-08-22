using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy , IDamageable
{

    public GameObject AcidEffectPrefab;
    public int Health {  get; set; }
    public override void Init()
    {
        base.Init();
    }
    public override void Movement()
    {

    }
    public void Damage()
    { }
    public void Attack()
    {
        Instantiate(AcidEffectPrefab,transform.position,Quaternion.identity);
    }
}
