using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : Character
{
    //Character에서 구현하세요 GetDameged()랑 Die()구현
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
        //애니메이션 실행
    }

    private void Attack()
    {
        //애니메이션 호출
        curAttackDelay += Time.deltaTime;
        if (state == 1)
        {
            if (curAttackDelay > attackDelay)
            {
                enemy.GetDameged(attackDamage);
                curAttackDelay = 0;
                if(!enemy.gameObject.activeSelf)
                {
                    Debug.Log(enemy.gameObject.name + "사망");
                    enemy = null;
                    state = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //공격 시작
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
        //공격 종료
    }
}
