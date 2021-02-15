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
    public virtual void Execute() 
    {
        nm.ResetAllNodes();
        GameObject.Find("Abilities").GetComponent<AbilityUI>().ResetAllButtons();
        tm.currentCharacter.GetComponent<Abilities>().CurrentAbility = null;
    }
    public virtual void Execute(GameObject node)
    {
        nm.ResetAllNodes();
    }

    public float Range
    {
        get { return range; }
    }
}
