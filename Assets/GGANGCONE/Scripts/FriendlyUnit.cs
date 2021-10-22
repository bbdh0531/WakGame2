using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyUnit : Character
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
        if (isStay)
        {
            if (curAttackTime > lastAttackTime && enemy != null)
            {
                //enemy �������Լ� ȣ��
            }
            curAttackTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            isStay = true;
            enemy = collision.gameObject.GetComponent<EnemyUnit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
        isStop = false;
    }

}
