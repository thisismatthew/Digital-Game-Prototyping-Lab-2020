using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]protected float range;
    protected GameManager gm;
    [HideInInspector]public bool isAttack;

    protected virtual void Start()
    {
        if (range < 1)
        {
            range = 1;
        }

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public virtual void DisplayRange() {}
    public virtual void Execute() {}
    public virtual void Execute(GameObject node){ }

    public float Range
    {
        get { return range; }
    }
}
