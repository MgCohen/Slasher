using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFocusTargetSignal
{
    public OnFocusTargetSignal(Transform target)
    {
        Target = target;
    }

    public Transform Target
    {
        get; private set;
    }
}
