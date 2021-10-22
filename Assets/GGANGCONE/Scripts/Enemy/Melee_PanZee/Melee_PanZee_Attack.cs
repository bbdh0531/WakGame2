using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_PanZee_Attack : MonoBehaviour
{
    public GameObject Pan;
    Melee_PanZee PCS;
    void Awake()
    {
        PCS = Pan.GetComponent<Melee_PanZee>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            PCS.state = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            PCS.state = 0;
        }
    }
}
