using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_PanZee : Enemy_Unit
{
    new protected void Attack()
    {
        if (state == 1 && curAttackDelay > attackDelay)
        {
            targetObject.GetComponent<Melee_WakDoo>().Damaged(attackDamage);
            Debug.Log("������ ����");
            curAttackDelay = 0;
        }
        curAttackDelay += Time.deltaTime;
    }
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Move();
        Attack();
    }
}
