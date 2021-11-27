using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inputs/Tap")]
public class TapInputRequirement : InputRequirement<TapInput>
{
    protected override bool ValidateInput(TapInput input)
    {
        return true;
    }
}
