using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFocusDirectionSignal
{
    public OnFocusDirectionSignal(Vector3 direction)
    {
        Direction = direction;
    }

    public Vector3 Direction
    {
        get; private set;
    }
}

public class OnReleaseFocusDirectionSignal
{

}
