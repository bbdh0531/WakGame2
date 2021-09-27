using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public int compensation_gold;

    int gold;
    public int stage_clear;
    public static Manager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void StageClear()
    {
        stage_clear++;
        gold += compensation_gold;
        UIManager.instance.SpecialCharacterUnLock();
    }

    // Update is called once per frame
}
