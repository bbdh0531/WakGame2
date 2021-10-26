using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : Character
{
    //Character���� �����ϼ��� GetDameged()�� Die()����
    EnemyUnit enemy;

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
        if (state == 1)
        {
            if (curAttackDelay > attackDelay && enemy != null)
            {
                enemy.GetDameged(attackDamage);
                curAttackDelay = 0;
            }
           curAttackDelay += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            state = 1;
            enemy = collision.gameObject.GetComponent<EnemyUnit>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        state = 0;
    }
}
