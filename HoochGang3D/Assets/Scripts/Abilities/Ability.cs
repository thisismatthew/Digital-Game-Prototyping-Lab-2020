using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected float range;

    public float GetRange()
    {
        return range;
    }
}
