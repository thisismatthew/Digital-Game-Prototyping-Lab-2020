using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]protected float range;
    protected TurnManager tm;
    protected NodeManager nm;
    [HideInInspector]public bool isAttack;

    protected virtual void Start()
    {
        if (range < 1)
        {
            range = 1;
        }

        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
        nm = GameObject.Find("GameManager").GetComponent<NodeManager>();
    }

    public virtual void DisplayRange() {}
    public virtual void Execute() {}
    public virtual void Execute(GameObject node){ }

    public float Range
    {
        get { return range; }
    }
}
