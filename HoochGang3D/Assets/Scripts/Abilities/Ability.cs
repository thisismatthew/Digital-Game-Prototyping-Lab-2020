using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected float range;

    protected virtual void DisplayRange() {}

    protected virtual void Execute() {}

    public float GetRange()
    {
        return range;
    }
}
