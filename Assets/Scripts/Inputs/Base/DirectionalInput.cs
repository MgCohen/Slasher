using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DirectionalInput : PlayerInput
{
    [Inject]
    private void Init(Vector3 rawDirection)
    {
        RawDirection = rawDirection;
        Direction = rawDirection.Unidirectional(m_state.target);
    }

    public Vector3 Direction
    {
        get; private set;
    }

    public Vector3 RawDirection
    {
        get; private set;
    }

    public override void UpdateValues()
    {
        m_values.RawInputDirection = RawDirection;
        m_values.InputDirection = Direction;
    }

    public class Factory: PlaceholderFactory<Vector3, DirectionalInput>
    {

    }
}
