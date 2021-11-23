using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inputs/Directional")]
public class DirectionalInputRequirement : InputRequirement<DirectionalInput>
{
    [SerializeField]
    private Vector3 m_direction;

    protected override bool ValidateInput(DirectionalInput input)
    {
        return (m_direction == input.Direction);
    }
}
