using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Character
{
    //Character���� �����ϼ��� GetDameged()�� Die()����
    Character ally;

    protected virtual void Start()
    {
        dir_pos.Set(-1, 0);
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
        Attack();
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void Die()
    {
        base.Die();
    }

    public override void GetDameged(int _damaged)
    {
        base.GetDameged(_damaged);
    }

    protected virtual void Attack()
    {
        curAttackDelay += Time.deltaTime;
        if (state == 1)
        {
            if (curAttackDelay > attackDelay)
            {
                //Debug.Log(gameObject.name+"�� ����!");
                ally.GetDameged(attackDamage);
                curAttackDelay = 0;
                if (!ally.gameObject.activeSelf)
                {
                    ally = null;
                    state = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //���� ����
        if (collision.gameObject.tag.Equals("Ally")&&ally == null)
        {
            state = 1;
            ally = collision.gameObject.GetComponent<AllyUnit>();
        }
        else if (collision.gameObject.tag.Equals("AllyHouse") && ally == null)
        {
            state = 1;
            ally = collision.gameObject.GetComponent<AllyHouse>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        //���� ����
        
    }
}
