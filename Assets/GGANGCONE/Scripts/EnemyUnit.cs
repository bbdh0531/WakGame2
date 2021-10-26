using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Character
{
    //Character에서 구현하세요 GetDameged()랑 Die()구현
    AllyUnit ally;

    void Start()
    {
        dir_pos.Set(-1, 0);
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        curAttackDelay = attackDelay;
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
        if (state == 1)
        {
            if (curAttackDelay > attackDelay && ally != null)
            {
                ally.GetDameged(attackDamage);
                curAttackDelay = 0;
            }
        }
        curAttackDelay += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("AllyUnit"))
        {
            state = 1;
            ally = collision.gameObject.GetComponent<AllyUnit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        state = 0;
    }

}
