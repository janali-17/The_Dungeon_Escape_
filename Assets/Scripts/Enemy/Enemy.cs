using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform WaypointA,WaypointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
   
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim"))
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {

        if (transform.position == WaypointA.position)
        {
            currentTarget = WaypointB.position;
            sprite.flipX = false;
        }
        else if (transform.position == WaypointB.position)
        {
            currentTarget = WaypointA.position;
            sprite.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        if (transform.position == currentTarget)
        {
            anim.SetTrigger("Idle");
        }
    }
}
