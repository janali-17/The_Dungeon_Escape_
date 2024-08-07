using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform WaypointA,WaypointB;
    protected Vector3 CurrentPos;

    public virtual void Attack()
    {
        Debug.Log("THis is :" + gameObject.name);
    }
    public abstract void Update();
}
