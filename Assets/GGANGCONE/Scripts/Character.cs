using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int curHp;
    public int maxHp;
    public float speed;
    public int attackDameged;
    public float curAttackTime;

    protected float lastAttackTime;
    protected Animator anim;
    protected Transform tr;
    protected bool isStop;
    protected bool isStay = false;
    protected Vector2 dir_pos;

    protected virtual void Move()
    {
        if (isStop)
            tr.Translate(dir_pos * speed * Time.deltaTime);
        else
            tr.Translate(Vector2.zero);
    }

    public virtual void GetDameged(int _damaged) 
    {
        //���� ������ Die() �Լ� ����
        //�ƴϸ� �������� ������
    }

    protected virtual void Die()
    {
        //���ӿ�����Ʈ ��Ȱ��ȭ
    }

}
