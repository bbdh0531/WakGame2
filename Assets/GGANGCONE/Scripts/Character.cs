using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp;
    public int curHp;
    public float speed;
    public int attackDamage;
    public float attackDelay;

    protected float curAttackDelay;
    protected Animator anim;
    protected Transform tr;
    protected int state; //0이동, 1공격
    protected Vector2 dir_pos;

    private void OnEnable()
    {
        curAttackDelay = attackDelay;
        curHp = maxHp;
    }

    protected virtual void Move()
    {
        if (state==0)
            tr.Translate(dir_pos * speed * Time.deltaTime);
        else
            tr.Translate(Vector2.zero);
    }

    public virtual void GetDameged(int damage) 
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            Die();
            Debug.Log(gameObject.name + " " + "사망");
        }
        else
        {
            Debug.Log(gameObject.name + " " + damage + "만큼 데미지 받음");
        }
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
