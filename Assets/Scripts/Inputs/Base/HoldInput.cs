using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HoldInput : PlayerInput
{
    [Inject]
    private void Init(float age)
    {
        Age = age;
    }

    public float Age
    {
        get; private set;
    }

    public override void UpdateValues()
    {
        m_values.Age = Age;
    }


    public class Factory : PlaceholderFactory<float, DirectionalInput>
    {

    }
}


