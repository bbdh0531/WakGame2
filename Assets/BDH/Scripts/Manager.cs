using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    public int compensation_gold;
    public int gold;

    public int stage_clear;
    public static Manager instance;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StageClear()
    {
        stage_clear++;
        gold += compensation_gold;
        UIManager.instance.SpecialCharacterUnLock();
    }

    // Update is called once per frame
}
