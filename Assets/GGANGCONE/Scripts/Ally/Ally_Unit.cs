using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_Unit : MonoBehaviour
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

    protected Transform Tr;
    protected Animator anim;
    private void Awake()
    {
        curAttackDelay = attackDelay;
    }
    protected void Move()
    {   
        if (state==0) {
            Tr.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
    protected void Attack()
    {
        if (state==1 && curAttackDelay > attackDelay) {
            targetObject.GetComponent<Enemy_Unit>().Damaged(attackDamage);
            Debug.Log("아군의 공격");
            curAttackDelay = 0;
        }
        curAttackDelay += Time.deltaTime;
    }

    public void Damaged(int damage)
    {
        Debug.Log("아군 피격됨");
        cur_hp -= damage;
        if (cur_hp <= 0)
        {
            Debug.Log(gameObject.name + "아군 사망");
            Destroy(gameObject);
        }
    }
}

