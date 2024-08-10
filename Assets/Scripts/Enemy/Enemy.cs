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
    protected bool isHit = false;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Player Player;
   
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim") && anim.GetBool("InCombat") == false)
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
        if(isHit == false) {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
            

                  
        if (transform.position == currentTarget)
        {
            anim.SetTrigger("Idle");
        }
        

         float distanceBetween = Vector3.Distance(transform.localPosition, Player.transform.localPosition);
        if(distanceBetween > 2)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }
}
