using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MossGiant : Enemy , IDamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();

        Vector3 Direction = Player.transform.localPosition - transform.localPosition;
        if (Direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
        else if (Direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }

    }
    public void Damage()
    {

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
