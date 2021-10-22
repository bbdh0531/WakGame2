using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Character
{
    //Character���� �����ϼ��� GetDameged()�� Die()����
    FriendlyUnit monster;

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
        if (isStay)
        {
            if (curAttackTime > lastAttackTime && monster != null)
            {
                //enemy �������Լ� ȣ��
            }
            curAttackTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("FriendlyUnit"))
        {
            isStay = true;
            monster = collision.gameObject.GetComponent<FriendlyUnit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
        isStop = false;
    }

}
