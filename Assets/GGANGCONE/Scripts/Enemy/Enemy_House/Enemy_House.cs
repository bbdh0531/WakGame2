using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_House : Enemy_Unit
{
    Melee_WakDoo Acs;
    new protected void Attack()
    {
        if (state == 1 && curAttackDelay > attackDelay)
        {
            if(targetObject==null)
            {   
                if(targetObject.name == "Melee_WakDoo")
                {
                    Acs = targetObject.GetComponent<Melee_WakDoo>();
                }
            }
            Acs.Damaged(attackDamage);
            Debug.Log("���� ������ ����");
            curAttackDelay = 0;
        }
        curAttackDelay += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Attack();
    }
}
