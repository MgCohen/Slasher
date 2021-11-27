using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInputBufferedSignal
{
    public OnInputBufferedSignal(PlayerInput input, bool isCached)
    {
        Input = input;
        IsCached = isCached;
    }

    public bool IsCached
    {
        get; private set;
    }

    public PlayerInput Input
    {
        get; private set;
    }
}
