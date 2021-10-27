using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedUni : EnemyUnit
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        curAttackDelay += Time.deltaTime;
        if (state == 1)
        {
            if (curAttackDelay > attackDelay)
            {
                EnemyBulletCreate();
                curAttackDelay = 0;
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ally"))
        {
            state = 1;
        }

        if (collision.gameObject.tag.Equals("AllyHouse"))
        {
            state = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ally"))
        {
            state = 0;
        }

        if (collision.gameObject.tag.Equals("AllyHouse"))
        {
            state = 0;
        }
    }

    void EnemyBulletCreate()
    {
        EenmyBullet tmp = Resources.Load<EenmyBullet>("EnemyBullet");
        EenmyBullet bullet = Instantiate(tmp);
        bullet.transform.position = tr.position;
    }
}
