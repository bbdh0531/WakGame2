using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyUnit : Character
{
    //Character에서 구현하세요 GetDameged()랑 Die()구현
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
        //애니메이션 실행
    }

    private void Attack()
    {
        //애니메이션 호출
        if (isStay)
        {
            if (curAttackTime > lastAttackTime && enemy != null)
            {
                //enemy 데미지함수 호출
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
