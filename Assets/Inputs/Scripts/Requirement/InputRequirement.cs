using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputRequirement<T> : InputRequirement where T : PlayerInput
{
    protected abstract bool ValidateInput(T input);
    
    public override bool ValidateInput(object obj)
    {
        if(obj.GetType() == typeof(T))
        {
            return ValidateInput(obj as T);
        }

        return false;
    }
}

public abstract class InputRequirement: ScriptableObject
{
    public abstract bool ValidateInput(object obj);
}