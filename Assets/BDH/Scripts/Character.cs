using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Friendly, Aggressive
}

public enum State
{
    Move, Attack, Die
}

public class Character : MonoBehaviour
{
    protected BattleState battle_state;
    protected int cur_hp;
    protected int max_hp;
    protected int attackdamege;
    protected float speed;
    protected Transform tr;
    protected Animator anim;
}

