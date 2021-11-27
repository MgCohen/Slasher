using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inputs/Any Directional")]
public class AnyDirectionalInputRequirement : InputRequirement<DirectionalInput>
{
    protected override bool ValidateInput(DirectionalInput input)
    {
        return true;
    }
}
