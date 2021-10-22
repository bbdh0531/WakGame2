using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHouse : Character
{
    public override void GetDameged(int _damaged)
    {
        base.GetDameged(_damaged);
    }

    private void FixedUpdate()
    {
        if (isStay)
        {
            //GetDameged() »£√‚
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyUnit"))
        {
            isStay = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyUnit"))
        {
            isStay = false;
        }
    }
}
