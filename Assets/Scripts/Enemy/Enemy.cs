using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Variables
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    protected bool isHit = false;
    protected bool isDead = false;
 
    // Handles
    [SerializeField]
    protected Transform WaypointA,WaypointB;
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Player Player;
    [SerializeField]
    protected GameObject DiamondPrefab;
    protected Diamond _diamond;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _diamond = GameObject.Find("Diamond").GetComponent<Diamond>();
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
        if(isDead == false)
        {
            Movement();
        }
        
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

        Vector3 Direction = Player.transform.localPosition - transform.localPosition;
        if (Direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
           
        }
        else if (Direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        //TO flip sprite after it get hit
        if (currentTarget == WaypointB.position && anim.GetBool("InCombat") == false)
        {
            sprite.flipX = false;
        }
        else if (currentTarget == WaypointA.position && anim.GetBool("InCombat") == false)
        {
            sprite.flipX = true;
        }

    }
}
