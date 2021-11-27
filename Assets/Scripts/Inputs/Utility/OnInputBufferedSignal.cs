using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInputBufferedSignal
{
    public OnInputBufferedSignal(PlayerInput input)
    {
        Input = input;
    }

    public PlayerInput Input
    {
        get; private set;
    }
}
