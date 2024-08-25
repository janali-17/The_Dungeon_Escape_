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
        Health = base.health;
    }
    public override void Update()
    {
    }
    public override void Movement()
    {

    }
    public void Damage()
    {
        if(isDead == true) 
            return;
        health--;
        if(health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(DiamondPrefab,transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    
    }
    public void Attack()
    {
       // StartCoroutine(WaitBeforeAttack());
        Instantiate(AcidEffectPrefab,transform.position,Quaternion.identity);
    }
    IEnumerator WaitBeforeAttack()
    {
        yield return new WaitForSeconds(Random.Range(4.0f, 7.0f));
    }
}
