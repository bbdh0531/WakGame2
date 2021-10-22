using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Unit : MonoBehaviour
{
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int attackDamage;
    [SerializeField]
    protected int attackDistance;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float attackDelay;
    

    public int state = 0;
    public GameObject targetObject;
    protected int cur_hp;
    protected float curAttackDelay;

    protected Transform tr;
    protected Animator anim;
    private void Awake()
    {
        curAttackDelay = attackDelay;
    }
    protected void Move()
    {   
        if (state==0) {
            tr.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
    protected void Attack()
    {
        if (state==1 && curAttackDelay > attackDelay) {
            targetObject.GetComponent<Ally_Unit>().Damaged(attackDamage);
            Debug.Log("������ ����");
            curAttackDelay = 0;
        }
        curAttackDelay += Time.deltaTime;
    }

    public void Damaged(int damage)
    {
        Debug.Log("���� �ǰݵ�");
        cur_hp -= damage;
        if (cur_hp <= 0)
        {
            Debug.Log(gameObject.name + "�Ʊ� ���");
            Destroy(gameObject);
        }
    }
}

