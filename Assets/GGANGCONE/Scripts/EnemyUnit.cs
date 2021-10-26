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
                Debug.Log(gameObject.name+"의 공격!");
                ally.GetDameged(attackDamage);
                curAttackDelay = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //공격 시작
        if (collision.gameObject.tag.Equals("Ally"))
        {
            state = 1;
            ally = collision.gameObject.GetComponent<AllyUnit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        //공격 종료
        state = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //피격 시작
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //피격 종료
    }
}
