using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtility
{
    public static Vector3 Convert(this Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }

    public static Vector3 GetDirectional(this Vector3 vector, Transform reference)
    {
        return reference.InverseTransformDirection(vector.normalized);
    }

    public static Vector3 Unidirectional(this Vector3 vector, Transform reference)
    {
        Vector3 directional = GetDirectional(vector, reference);
        if(Mathf.Abs(directional.x) >= Mathf.Abs(directional.y))
        {
            return new Vector3(directional.x/Mathf.Abs(directional.x), 0, 0);
        }
        else
        {
            return new Vector3(0, 0, directional.z/Mathf.Abs(directional.z));
        }
    }
}
