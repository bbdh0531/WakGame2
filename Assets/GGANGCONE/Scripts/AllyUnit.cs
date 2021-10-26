using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyUnit : Character
{
    //Character에서 구현하세요 GetDameged()랑 Die()구현
    EnemyUnit enemy;
    Collider2D collision;
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
                //Debug.Log(gameObject.name+"의 공격");
                enemy.GetDameged(attackDamage);
                curAttackDelay = 0;
                if(!enemy.gameObject.activeSelf)
                {
                    Debug.Log(enemy.gameObject.name + "die");
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        //공격 종료
        
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
