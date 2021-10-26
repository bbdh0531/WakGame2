using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Character
{
    //Character���� �����ϼ��� GetDameged()�� Die()����
    AllyUnit ally;

    void Start()
    {
        dir_pos.Set(-1, 0);
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
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

    private void Attack()
    {
        curAttackDelay += Time.deltaTime;
        if (state == 1)
        {
            if (curAttackDelay > attackDelay && ally != null)
            {
                Debug.Log(gameObject.name+"�� ����!");
                ally.GetDameged(attackDamage);
                curAttackDelay = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //���� ����
        if (collision.gameObject.tag.Equals("Ally"))
        {
            state = 1;
            ally = collision.gameObject.GetComponent<AllyUnit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        //���� ����
        state = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ǰ� ����
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ǰ� ����
    }
}
