using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_House_Attack : MonoBehaviour
{
    public GameObject House;
    Ally_House Hcs;
    void Awake()
    {
        Hcs = House.GetComponent<Ally_House>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Hcs.state = 1;
            Hcs.targetObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Hcs.state = 0;
            Hcs.targetObject = null;
        }
    }
}
