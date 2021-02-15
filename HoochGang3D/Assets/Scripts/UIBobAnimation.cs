using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBobAnimation : MonoBehaviour
{
    public AnimationCurve bobbing;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, bobbing.Evaluate((Time.time % bobbing.length)), transform.localPosition.z);
    }
}
