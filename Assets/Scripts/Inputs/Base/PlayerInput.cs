using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public abstract class PlayerInput
{
    [Inject]
    protected InputValues m_values;
    [Inject]
    protected CharacterState m_state;

    public abstract void UpdateValues();
}


