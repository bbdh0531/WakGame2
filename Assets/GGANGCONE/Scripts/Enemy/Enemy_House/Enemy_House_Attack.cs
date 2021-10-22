using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_House_Attack : MonoBehaviour
{
    public GameObject House;
    Enemy_House Hcs;
    void Awake()
    {
        Hcs = House.GetComponent<Enemy_House>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            Hcs.state = 1;
            Hcs.targetObject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            Hcs.state = 0;
            Hcs.targetObject = null;
        }
    }
}
