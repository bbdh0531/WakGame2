using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_WakDoo : Ally_Unit
{
    void Start()
    {
        Tr = GetComponent<Transform>();
    }
    new protected void Attack()
    {
        if (state == 1 && curAttackDelay > attackDelay)
        {
            targetObject.GetComponent<Melee_PanZee>().Damaged(attackDamage);
            Debug.Log("아군의 공격");
            curAttackDelay = 0;
        }
        curAttackDelay += Time.deltaTime;
    }

    void FixedUpdate()
    {   
        Move();
        Attack();
    }
}  



