using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInputSignal
{
    public OnInputSignal(PlayerInput input)
    {
        Input = input;
    }

    public PlayerInput Input
    {
        get; private set;
    }
}
