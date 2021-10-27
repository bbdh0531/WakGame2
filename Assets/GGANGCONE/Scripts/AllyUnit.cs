using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : Character
{
    //Character���� �����ϼ��� GetDameged()�� Die()����
    Character enemy;
    void Start()
    {
        dir_pos.Set(1, 0);
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    protected override void Move()
    {
        base.Move();    
    }

    public override void GetDameged(int _damaged)
    {
        base.GetDameged(_damaged);
    }

    protected override void Die()
    {
        base.Die();
        //�ִϸ��̼� ����
    }

    private void Attack()
    {
        //�ִϸ��̼� ȣ��
        curAttackDelay += Time.deltaTime;
        if (state == 1)
        {
            if (curAttackDelay > attackDelay)
            {
                enemy.GetDameged(attackDamage);
                curAttackDelay = 0;
                if(!enemy.gameObject.activeSelf)
                {
                    Debug.Log(enemy.gameObject.name + "���");
                    enemy = null;
                    state = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //���� ����
        if (collision.gameObject.tag.Equals("Enemy")&&enemy == null)
        {
            state = 1;
            enemy = collision.gameObject.GetComponent<EnemyUnit>();
        }
        else if (collision.gameObject.tag.Equals("EnemyHouse") && enemy == null)
        {
            state = 1;
            enemy = collision.gameObject.GetComponent<EnemyHouse>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        //���� ����
    }
}
