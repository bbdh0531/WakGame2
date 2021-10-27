using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBullet : Bullet
{
    public int attack_damage;
    public float speed;
    Character character;
    Transform tr;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            character = collision.gameObject.GetComponent<EnemyUnit>();
            character.GetDameged(attack_damage);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag.Equals("EnemyHouse"))
        {
            character = collision.gameObject.GetComponent<EnemyHouse>();
            character.GetDameged(attack_damage);
            gameObject.SetActive(false);
        }
    }

}
