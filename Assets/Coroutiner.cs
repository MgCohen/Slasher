using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Coroutiner: MonoBehaviour
{
    public static Coroutiner Dummy
    {
        get
        {
            if(m_dummy == null)
            {
                m_dummy = new GameObject("Coroutiner Dummy").AddComponent<Coroutiner>();
            }

            return m_dummy;
        }
    }

    private static Coroutiner m_dummy;

    public static Coroutine DoRoutine(IEnumerator coroutine)
    {
       return Dummy.StartCoroutine(coroutine);
    }

    public static void WaitAndDo(float time, Action callback)
    {
        DoRoutine(WaitAndDoCO(time, callback));
    }

    static IEnumerator WaitAndDoCO(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
}
