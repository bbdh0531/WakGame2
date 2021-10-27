using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyRangedUnit : AllyUnit
{
    // Start is called before the first frame update
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
                AllyBulletCreate();
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
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            state = 1;
        }

        if(collision.gameObject.tag.Equals("EnemyHouse"))
        {
            state = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            state = 0;
        }

        if (collision.gameObject.tag.Equals("EnemyHouse"))
        {
            state = 0;
        }
    }

    void AllyBulletCreate()
    {
        AllyBullet tmp = Resources.Load<AllyBullet>("Bullet");
        AllyBullet bullet = Instantiate(tmp);
        bullet.transform.position = tr.position;
    }

}
