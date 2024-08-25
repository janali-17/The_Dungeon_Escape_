using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("Hit :" + other.name);

        IDamageable Hit = other.GetComponent<IDamageable>();

        if (Hit != null)
        {
            if(_canDamage == true) 
            {
                Hit.Damage();
            }
            _canDamage = false;
        }
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true ;
    }
}
