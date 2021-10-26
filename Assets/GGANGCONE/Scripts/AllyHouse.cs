using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHouse : Character
{
    public override void GetDameged(int _damaged)
    {
        base.GetDameged(_damaged);
    }

    private void FixedUpdate()
    {
        if (state == 0)
        {
            //GetDameged() »£√‚
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyUnit"))
        {
            state = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyUnit"))
        {
            state = 0;
        }
    }
}
