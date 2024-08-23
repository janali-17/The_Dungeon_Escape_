using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    Spider _spider;
    Animator _animator;

    bool waitfor = false;

    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (waitfor == false) 
        { 
            StartCoroutine(WaitBeforeAttack());
            _animator.SetTrigger("Attack");
        }
    }
    public void Fire()
    {
        _spider.Attack();
    }
    IEnumerator WaitBeforeAttack()
    {
        waitfor = true;
        yield return new WaitForSeconds(Random.Range(5.0f,7.0f));
        waitfor = false;
    }
}
