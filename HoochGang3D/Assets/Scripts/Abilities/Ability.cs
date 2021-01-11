using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]protected float range;

    protected virtual void Start()
    {
        if (range < 1)
        {
            range = 1;
        }
    }

    public virtual void DisplayRange() {}

    public virtual void Execute(Vector3 target) {}

    public float Range
    {
        get { return range; }
    }
}
