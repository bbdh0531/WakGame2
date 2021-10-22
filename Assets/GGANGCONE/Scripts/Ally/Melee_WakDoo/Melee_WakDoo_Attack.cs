using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_WakDoo_Attack : MonoBehaviour
{
    public GameObject Wak;
    Melee_WakDoo WCS;
    void Awake()
    {
        WCS = Wak.GetComponent<Melee_WakDoo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            WCS.state = 1;
            WCS.targetObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            WCS.state = 0;
            WCS.targetObject = GameObject.Find("Enemy_House");
        }
    }
}
